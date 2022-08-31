@file:Suppress("UnstableApiUsage")

package com.github.rafaelldi.lensplugin

import com.intellij.microservices.endpoints.EndpointsProvider
import com.intellij.microservices.endpoints.EndpointsSidePanel
import com.intellij.openapi.actionSystem.DataContext
import com.intellij.openapi.actionSystem.PlatformCoreDataKeys
import com.intellij.openapi.components.service
import com.intellij.openapi.project.Project
import com.intellij.ui.components.JBPanelWithEmptyText
import com.intellij.ui.dsl.builder.panel
import com.intellij.util.ArrayUtil
import java.awt.BorderLayout
import javax.swing.JComponent

class OpenTelemetryEndpointsSidePanel(private val project: Project) : EndpointsSidePanel {
    override val component: JComponent = JBPanelWithEmptyText(BorderLayout())
        .withEmptyText("No data available")

    override val title: String = "OpenTelemetry"

    override fun isAvailable(dataContext: DataContext): Boolean {
        val items = dataContext.getData(PlatformCoreDataKeys.SELECTED_ITEMS) ?: ArrayUtil.EMPTY_OBJECT_ARRAY
        return items.asSequence()
            .filterIsInstance<DataContext>()
            .any { it.getData(EndpointsProvider.URL_TARGET_INFO) != null }
    }

    override fun update(dataContext: DataContext, isActive: Boolean) {
        if (!isActive) {
            return
        }

        component.removeAll()

        val selectedItems = dataContext.getData(PlatformCoreDataKeys.SELECTED_ITEMS) ?: return
        val urlTargetInfo = selectedItems.asSequence()
            .filterIsInstance<DataContext>()
            .mapNotNull { it.getData(EndpointsProvider.URL_TARGET_INFO) }
            .firstOrNull()
            ?.firstOrNull()
            ?: return

        val method = urlTargetInfo.methods.firstOrNull() ?: return

        val dataProvider = project.service<OpenTelemetryEndpointDataProvider>()
        val openTelemetryData = dataProvider.getData(Pair(method, urlTargetInfo.path.getPresentation())) ?: return

        val panel = panel {
            row("Count:") { label(openTelemetryData.first.toString()) }
            row("Average:") { label(openTelemetryData.second.toString()) }
        }

        component.add(panel, BorderLayout.CENTER)
    }
}