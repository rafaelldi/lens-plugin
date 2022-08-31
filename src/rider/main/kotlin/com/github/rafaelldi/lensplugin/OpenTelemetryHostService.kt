package com.github.rafaelldi.lensplugin

import com.github.rafaelldi.lensplugin.generated.AspNetCoreActivity
import com.github.rafaelldi.lensplugin.generated.LensHostModel
import com.github.rafaelldi.lensplugin.generated.lensHostModel
import com.intellij.openapi.components.Service
import com.intellij.openapi.components.service
import com.intellij.openapi.diagnostic.thisLogger
import com.intellij.openapi.project.Project
import com.jetbrains.rd.platform.util.idea.ProtocolSubscribedProjectComponent
import com.jetbrains.rider.projectView.solution

@Service
class OpenTelemetryHostService(project: Project) : ProtocolSubscribedProjectComponent(project) {
    companion object {
        const val OpenTelemetryRdPort = 8686
    }

    private val model: LensHostModel

    init {
        model = project.solution.lensHostModel
        model.activityReceived.advise(projectComponentLifetime) { onActivity(it) }
    }

    fun startOpenTelemetryHost() {
        thisLogger().info("Starting OpenTelemetry host")
        project.solution.lensHostModel.startOpenTelemetryHost.fire(OpenTelemetryRdPort)
    }

    private fun onActivity(activity: AspNetCoreActivity) {
        thisLogger().info("Activity received: ${activity.displayName}, ${activity.method}, ${activity.target}, ${activity.route}, ${activity.statusCode}, ${activity.duration}")

        if (activity.method == null || activity.route == null) {
            return
        }

        val dataProvider = project.service<OpenTelemetryEndpointDataProvider>()
        dataProvider.addData(
            Pair(activity.method, activity.route),
            activity.duration
        )
    }
}