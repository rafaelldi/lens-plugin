@file:Suppress("EXPERIMENTAL_API_USAGE","EXPERIMENTAL_UNSIGNED_LITERALS","PackageDirectoryMismatch","UnusedImport","unused","LocalVariableName","CanBeVal","PropertyName","EnumEntryName","ClassName","ObjectPropertyName","UnnecessaryVariable","SpellCheckingInspection")
package com.github.rafaelldi.lensplugin.generated

import com.jetbrains.rd.framework.*
import com.jetbrains.rd.framework.base.*
import com.jetbrains.rd.framework.impl.*

import com.jetbrains.rd.util.lifetime.*
import com.jetbrains.rd.util.reactive.*
import com.jetbrains.rd.util.string.*
import com.jetbrains.rd.util.*
import kotlin.reflect.KClass
import kotlin.jvm.JvmStatic



/**
 * #### Generated from [LensHostModel.kt:10]
 */
class LensHostModel internal constructor(
) : RdExtBase() {
    //companion
    
    companion object : ISerializersOwner {
        
        override fun registerSerializersCore(serializers: ISerializers)  {
        }
        
        
        
        
        
        const val serializationHash = -3822002316053087048L
        
    }
    override val serializersOwner: ISerializersOwner get() = LensHostModel
    override val serializationHash: Long get() = LensHostModel.serializationHash
    
    //fields
    //methods
    //initializer
    //secondary constructor
    //equals trait
    //hash code trait
    //pretty print
    override fun print(printer: PrettyPrinter)  {
        printer.println("LensHostModel (")
        printer.print(")")
    }
    //deepClone
    override fun deepClone(): LensHostModel   {
        return LensHostModel(
        )
    }
    //contexts
}
val com.jetbrains.rd.ide.model.Solution.lensHostModel get() = getOrCreateExtension("lensHostModel", ::LensHostModel)

