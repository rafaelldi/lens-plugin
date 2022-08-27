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
class LensHostModel private constructor(
    private val _startOpenTelemetryHost: RdSignal<Int>,
    private val _activityReceived: RdSignal<AspNetCoreActivity>
) : RdExtBase() {
    //companion
    
    companion object : ISerializersOwner {
        
        override fun registerSerializersCore(serializers: ISerializers)  {
            serializers.register(AspNetCoreActivity)
        }
        
        
        
        
        
        const val serializationHash = 6824238146651358051L
        
    }
    override val serializersOwner: ISerializersOwner get() = LensHostModel
    override val serializationHash: Long get() = LensHostModel.serializationHash
    
    //fields
    val startOpenTelemetryHost: ISignal<Int> get() = _startOpenTelemetryHost
    val activityReceived: ISource<AspNetCoreActivity> get() = _activityReceived
    //methods
    //initializer
    init {
        bindableChildren.add("startOpenTelemetryHost" to _startOpenTelemetryHost)
        bindableChildren.add("activityReceived" to _activityReceived)
    }
    
    //secondary constructor
    internal constructor(
    ) : this(
        RdSignal<Int>(FrameworkMarshallers.Int),
        RdSignal<AspNetCoreActivity>(AspNetCoreActivity)
    )
    
    //equals trait
    //hash code trait
    //pretty print
    override fun print(printer: PrettyPrinter)  {
        printer.println("LensHostModel (")
        printer.indent {
            print("startOpenTelemetryHost = "); _startOpenTelemetryHost.print(printer); println()
            print("activityReceived = "); _activityReceived.print(printer); println()
        }
        printer.print(")")
    }
    //deepClone
    override fun deepClone(): LensHostModel   {
        return LensHostModel(
            _startOpenTelemetryHost.deepClonePolymorphic(),
            _activityReceived.deepClonePolymorphic()
        )
    }
    //contexts
}
val com.jetbrains.rd.ide.model.Solution.lensHostModel get() = getOrCreateExtension("lensHostModel", ::LensHostModel)



/**
 * #### Generated from [LensHostModel.kt:11]
 */
data class AspNetCoreActivity (
    val displayName: String,
    val method: String?,
    val target: String?,
    val route: String?,
    val statusCode: Int?,
    val duration: Long
) : IPrintable {
    //companion
    
    companion object : IMarshaller<AspNetCoreActivity> {
        override val _type: KClass<AspNetCoreActivity> = AspNetCoreActivity::class
        
        @Suppress("UNCHECKED_CAST")
        override fun read(ctx: SerializationCtx, buffer: AbstractBuffer): AspNetCoreActivity  {
            val displayName = buffer.readString()
            val method = buffer.readNullable { buffer.readString() }
            val target = buffer.readNullable { buffer.readString() }
            val route = buffer.readNullable { buffer.readString() }
            val statusCode = buffer.readNullable { buffer.readInt() }
            val duration = buffer.readLong()
            return AspNetCoreActivity(displayName, method, target, route, statusCode, duration)
        }
        
        override fun write(ctx: SerializationCtx, buffer: AbstractBuffer, value: AspNetCoreActivity)  {
            buffer.writeString(value.displayName)
            buffer.writeNullable(value.method) { buffer.writeString(it) }
            buffer.writeNullable(value.target) { buffer.writeString(it) }
            buffer.writeNullable(value.route) { buffer.writeString(it) }
            buffer.writeNullable(value.statusCode) { buffer.writeInt(it) }
            buffer.writeLong(value.duration)
        }
        
        
    }
    //fields
    //methods
    //initializer
    //secondary constructor
    //equals trait
    override fun equals(other: Any?): Boolean  {
        if (this === other) return true
        if (other == null || other::class != this::class) return false
        
        other as AspNetCoreActivity
        
        if (displayName != other.displayName) return false
        if (method != other.method) return false
        if (target != other.target) return false
        if (route != other.route) return false
        if (statusCode != other.statusCode) return false
        if (duration != other.duration) return false
        
        return true
    }
    //hash code trait
    override fun hashCode(): Int  {
        var __r = 0
        __r = __r*31 + displayName.hashCode()
        __r = __r*31 + if (method != null) method.hashCode() else 0
        __r = __r*31 + if (target != null) target.hashCode() else 0
        __r = __r*31 + if (route != null) route.hashCode() else 0
        __r = __r*31 + if (statusCode != null) statusCode.hashCode() else 0
        __r = __r*31 + duration.hashCode()
        return __r
    }
    //pretty print
    override fun print(printer: PrettyPrinter)  {
        printer.println("AspNetCoreActivity (")
        printer.indent {
            print("displayName = "); displayName.print(printer); println()
            print("method = "); method.print(printer); println()
            print("target = "); target.print(printer); println()
            print("route = "); route.print(printer); println()
            print("statusCode = "); statusCode.print(printer); println()
            print("duration = "); duration.print(printer); println()
        }
        printer.print(")")
    }
    //deepClone
    //contexts
}
