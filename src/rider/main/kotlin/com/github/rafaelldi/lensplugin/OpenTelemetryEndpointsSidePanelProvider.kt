@file:Suppress("UnstableApiUsage")

package com.github.rafaelldi.lensplugin

import com.intellij.microservices.endpoints.EndpointsSidePanel
import com.intellij.microservices.endpoints.EndpointsSidePanelProvider
import com.intellij.openapi.project.Project

class OpenTelemetryEndpointsSidePanelProvider: EndpointsSidePanelProvider {
    override fun create(project: Project): EndpointsSidePanel = OpenTelemetryEndpointsSidePanel(project)
}