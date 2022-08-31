package com.github.rafaelldi.lensplugin

import com.intellij.openapi.components.Service
import kotlin.time.Duration
import kotlin.time.Duration.Companion.nanoseconds

@Service
class OpenTelemetryEndpointDataProvider {
    private val endpointData: MutableMap<Pair<String, String>, MutableList<Long>> = mutableMapOf()

    fun addData(endpoint: Pair<String, String>, duration: Long) {
        if (endpointData.containsKey(endpoint)) {
            endpointData[endpoint]?.add(duration)
        } else {
            endpointData[endpoint] = mutableListOf(duration)
        }
    }

    fun getData(endpoint: Pair<String, String>): Pair<Int, Duration>? {
        val durations = endpointData[endpoint] ?: return null
        return Pair(durations.count(), (durations.average() / 100).nanoseconds)
    }
}