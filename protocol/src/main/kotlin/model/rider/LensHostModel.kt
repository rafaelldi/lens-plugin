package model.rider

import com.jetbrains.rd.generator.nova.*
import com.jetbrains.rd.generator.nova.PredefinedType.*
import com.jetbrains.rd.generator.nova.csharp.CSharp50Generator
import com.jetbrains.rd.generator.nova.kotlin.Kotlin11Generator
import com.jetbrains.rider.model.nova.ide.SolutionModel

@Suppress("unused")
object LensHostModel : Ext(SolutionModel.Solution) {
    private val AspNetCoreActivity = structdef {
        field("displayName", string)
        field("method", string.nullable)
        field("target", string.nullable)
        field("route", string.nullable)
        field("statusCode", int.nullable)
        field("duration", long)
    }

    init {
        setting(CSharp50Generator.Namespace, "LensPlugin.Generated")
        setting(Kotlin11Generator.Namespace, "com.github.rafaelldi.lensplugin.generated")

        source("startOpenTelemetryHost", int)
        sink("activityReceived", AspNetCoreActivity)
    }
}