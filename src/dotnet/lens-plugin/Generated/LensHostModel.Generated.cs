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
    
    //private fields
    //primary constructor
    internal LensHostModel(
    )
    {
    }
    //secondary constructor
    //deconstruct trait
    //statics
    
    
    
    protected override long SerializationHash => -3822002316053087048L;
    
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
}