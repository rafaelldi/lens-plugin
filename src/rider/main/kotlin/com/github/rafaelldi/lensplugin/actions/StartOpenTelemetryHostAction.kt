package com.github.rafaelldi.lensplugin.actions

import com.github.rafaelldi.lensplugin.generated.lensHostModel
import com.intellij.openapi.actionSystem.AnAction
import com.intellij.openapi.actionSystem.AnActionEvent
import com.intellij.openapi.diagnostic.thisLogger
import com.jetbrains.rider.projectView.solution

class StartOpenTelemetryHostAction: AnAction() {
    override fun actionPerformed(e: AnActionEvent) {
        val project = e.project ?: return
        val port = 8686
        thisLogger().info("Starting OpenTelemetry host on port $port")
        project.solution.lensHostModel.startOpenTelemetryHost.fire(port)
    }
}