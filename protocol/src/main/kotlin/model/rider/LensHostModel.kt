package model.rider

import com.jetbrains.rd.generator.nova.Ext
import com.jetbrains.rd.generator.nova.csharp.CSharp50Generator
import com.jetbrains.rd.generator.nova.kotlin.Kotlin11Generator
import com.jetbrains.rd.generator.nova.setting
import com.jetbrains.rider.model.nova.ide.SolutionModel

@Suppress("unused")
object LensHostModel : Ext(SolutionModel.Solution) {
    init {
        setting(CSharp50Generator.Namespace, "LensPlugin.Generated")
        setting(Kotlin11Generator.Namespace, "com.github.rafaelldi.lensplugin.generated")
    }
}