//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a RdGen v1.10.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

using JetBrains.Core;
using JetBrains.Diagnostics;
using JetBrains.Collections;
using JetBrains.Collections.Viewable;
using JetBrains.Lifetimes;
using JetBrains.Serialization;
using JetBrains.Rd;
using JetBrains.Rd.Base;
using JetBrains.Rd.Impl;
using JetBrains.Rd.Tasks;
using JetBrains.Rd.Util;
using JetBrains.Rd.Text;


// ReSharper disable RedundantEmptyObjectCreationArgumentList
// ReSharper disable InconsistentNaming
// ReSharper disable RedundantOverflowCheckingContext


namespace LensPlugin.Generated
{
  
  
  /// <summary>
  /// <p>Generated from: LensHostModel.kt:10</p>
  /// </summary>
  public class LensHostModel : RdExtBase
  {
    //fields
    //public fields
    [NotNull] public ISource<int> StartOpenTelemetryHost => _StartOpenTelemetryHost;
    [NotNull] public void ActivityReceived(AspNetCoreActivity value) => _ActivityReceived.Fire(value);
    
    //private fields
    [NotNull] private readonly RdSignal<int> _StartOpenTelemetryHost;
    [NotNull] private readonly RdSignal<AspNetCoreActivity> _ActivityReceived;
    
    //primary constructor
    private LensHostModel(
      [NotNull] RdSignal<int> startOpenTelemetryHost,
      [NotNull] RdSignal<AspNetCoreActivity> activityReceived
    )
    {
      if (startOpenTelemetryHost == null) throw new ArgumentNullException("startOpenTelemetryHost");
      if (activityReceived == null) throw new ArgumentNullException("activityReceived");
      
      _StartOpenTelemetryHost = startOpenTelemetryHost;
      _ActivityReceived = activityReceived;
      BindableChildren.Add(new KeyValuePair<string, object>("startOpenTelemetryHost", _StartOpenTelemetryHost));
      BindableChildren.Add(new KeyValuePair<string, object>("activityReceived", _ActivityReceived));
    }
    //secondary constructor
    internal LensHostModel (
    ) : this (
      new RdSignal<int>(JetBrains.Rd.Impl.Serializers.ReadInt, JetBrains.Rd.Impl.Serializers.WriteInt),
      new RdSignal<AspNetCoreActivity>(AspNetCoreActivity.Read, AspNetCoreActivity.Write)
    ) {}
    //deconstruct trait
    //statics
    
    
    
    protected override long SerializationHash => 6824238146651358051L;
    
    protected override Action<ISerializers> Register => RegisterDeclaredTypesSerializers;
    public static void RegisterDeclaredTypesSerializers(ISerializers serializers)
    {
      
      serializers.RegisterToplevelOnce(typeof(JetBrains.Rider.Model.IdeRoot), JetBrains.Rider.Model.IdeRoot.RegisterDeclaredTypesSerializers);
    }
    
    
    //constants
    
    //custom body
    //methods
    //equals trait
    //hash code trait
    //pretty print
    public override void Print(PrettyPrinter printer)
    {
      printer.Println("LensHostModel (");
      using (printer.IndentCookie()) {
        printer.Print("startOpenTelemetryHost = "); _StartOpenTelemetryHost.PrintEx(printer); printer.Println();
        printer.Print("activityReceived = "); _ActivityReceived.PrintEx(printer); printer.Println();
      }
      printer.Print(")");
    }
    //toString
    public override string ToString()
    {
      var printer = new SingleLinePrettyPrinter();
      Print(printer);
      return printer.ToString();
    }
  }
  public static class SolutionLensHostModelEx
   {
    public static LensHostModel GetLensHostModel(this JetBrains.Rider.Model.Solution solution)
    {
      return solution.GetOrCreateExtension("lensHostModel", () => new LensHostModel());
    }
  }
  
  
  /// <summary>
  /// <p>Generated from: LensHostModel.kt:11</p>
  /// </summary>
  public sealed class AspNetCoreActivity : IPrintable, IEquatable<AspNetCoreActivity>
  {
    //fields
    //public fields
    [NotNull] public string DisplayName {get; private set;}
    [CanBeNull] public string Method {get; private set;}
    [CanBeNull] public string Target {get; private set;}
    [CanBeNull] public string Route {get; private set;}
    [CanBeNull] public int? StatusCode {get; private set;}
    public long Duration {get; private set;}
    
    //private fields
    //primary constructor
    public AspNetCoreActivity(
      [NotNull] string displayName,
      [CanBeNull] string method,
      [CanBeNull] string target,
      [CanBeNull] string route,
      [CanBeNull] int? statusCode,
      long duration
    )
    {
      if (displayName == null) throw new ArgumentNullException("displayName");
      
      DisplayName = displayName;
      Method = method;
      Target = target;
      Route = route;
      StatusCode = statusCode;
      Duration = duration;
    }
    //secondary constructor
    //deconstruct trait
    public void Deconstruct([NotNull] out string displayName, [CanBeNull] out string method, [CanBeNull] out string target, [CanBeNull] out string route, [CanBeNull] out int? statusCode, out long duration)
    {
      displayName = DisplayName;
      method = Method;
      target = Target;
      route = Route;
      statusCode = StatusCode;
      duration = Duration;
    }
    //statics
    
    public static CtxReadDelegate<AspNetCoreActivity> Read = (ctx, reader) => 
    {
      var displayName = reader.ReadString();
      var method = ReadStringNullable(ctx, reader);
      var target = ReadStringNullable(ctx, reader);
      var route = ReadStringNullable(ctx, reader);
      var statusCode = ReadIntNullable(ctx, reader);
      var duration = reader.ReadLong();
      var _result = new AspNetCoreActivity(displayName, method, target, route, statusCode, duration);
      return _result;
    };
    public static CtxReadDelegate<string> ReadStringNullable = JetBrains.Rd.Impl.Serializers.ReadString.NullableClass();
    public static CtxReadDelegate<int?> ReadIntNullable = JetBrains.Rd.Impl.Serializers.ReadInt.NullableStruct();
    
    public static CtxWriteDelegate<AspNetCoreActivity> Write = (ctx, writer, value) => 
    {
      writer.Write(value.DisplayName);
      WriteStringNullable(ctx, writer, value.Method);
      WriteStringNullable(ctx, writer, value.Target);
      WriteStringNullable(ctx, writer, value.Route);
      WriteIntNullable(ctx, writer, value.StatusCode);
      writer.Write(value.Duration);
    };
    public static  CtxWriteDelegate<string> WriteStringNullable = JetBrains.Rd.Impl.Serializers.WriteString.NullableClass();
    public static  CtxWriteDelegate<int?> WriteIntNullable = JetBrains.Rd.Impl.Serializers.WriteInt.NullableStruct();
    
    //constants
    
    //custom body
    //methods
    //equals trait
    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != GetType()) return false;
      return Equals((AspNetCoreActivity) obj);
    }
    public bool Equals(AspNetCoreActivity other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return DisplayName == other.DisplayName && Equals(Method, other.Method) && Equals(Target, other.Target) && Equals(Route, other.Route) && Equals(StatusCode, other.StatusCode) && Duration == other.Duration;
    }
    //hash code trait
    public override int GetHashCode()
    {
      unchecked {
        var hash = 0;
        hash = hash * 31 + DisplayName.GetHashCode();
        hash = hash * 31 + (Method != null ? Method.GetHashCode() : 0);
        hash = hash * 31 + (Target != null ? Target.GetHashCode() : 0);
        hash = hash * 31 + (Route != null ? Route.GetHashCode() : 0);
        hash = hash * 31 + (StatusCode != null ? StatusCode.GetHashCode() : 0);
        hash = hash * 31 + Duration.GetHashCode();
        return hash;
      }
    }
    //pretty print
    public void Print(PrettyPrinter printer)
    {
      printer.Println("AspNetCoreActivity (");
      using (printer.IndentCookie()) {
        printer.Print("displayName = "); DisplayName.PrintEx(printer); printer.Println();
        printer.Print("method = "); Method.PrintEx(printer); printer.Println();
        printer.Print("target = "); Target.PrintEx(printer); printer.Println();
        printer.Print("route = "); Route.PrintEx(printer); printer.Println();
        printer.Print("statusCode = "); StatusCode.PrintEx(printer); printer.Println();
        printer.Print("duration = "); Duration.PrintEx(printer); printer.Println();
      }
      printer.Print(")");
    }
    //toString
    public override string ToString()
    {
      var printer = new SingleLinePrettyPrinter();
      Print(printer);
      return printer.ToString();
    }
  }
}
