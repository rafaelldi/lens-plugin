package com.github.rafaelldi.lensplugin

import com.intellij.openapi.components.service
import com.intellij.openapi.project.Project
import com.intellij.openapi.startup.StartupActivity

class StartOpenTelemetryHostStartupActivity: StartupActivity {
    override fun runActivity(project: Project) {
        val service = project.service<OpenTelemetryHostService>()
        service.startOpenTelemetryHost()
    }
}