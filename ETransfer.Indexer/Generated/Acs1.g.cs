// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: acs1.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace AElf.Standards.ACS1 {

  /// <summary>Holder for reflection information generated from acs1.proto</summary>
  public static partial class Acs1Reflection {

    #region Descriptor
    /// <summary>File descriptor for acs1.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static Acs1Reflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgphY3MxLnByb3RvEgRhY3MxGhJhZWxmL29wdGlvbnMucHJvdG8aG2dvb2ds",
            "ZS9wcm90b2J1Zi9lbXB0eS5wcm90bxoeZ29vZ2xlL3Byb3RvYnVmL3dyYXBw",
            "ZXJzLnByb3RvGg9hZWxmL2NvcmUucHJvdG8aFGF1dGhvcml0eV9pbmZvLnBy",
            "b3RvIloKCk1ldGhvZEZlZXMSEwoLbWV0aG9kX25hbWUYASABKAkSHQoEZmVl",
            "cxgCIAMoCzIPLmFjczEuTWV0aG9kRmVlEhgKEGlzX3NpemVfZmVlX2ZyZWUY",
            "AyABKAgiLgoJTWV0aG9kRmVlEg4KBnN5bWJvbBgBIAEoCRIRCgliYXNpY19m",
            "ZWUYAiABKAMiVgoMTWV0aG9kRmVlU2V0Eg4KBm1ldGhvZBgBIAEoCRIOCgZz",
            "eW1ib2wYAiABKAkSDwoHb2xkX2ZlZRgDIAEoAxIPCgduZXdfZmVlGAQgASgD",
            "OgSguxgBMq4CChlNZXRob2RGZWVQcm92aWRlckNvbnRyYWN0EjoKDFNldE1l",
            "dGhvZEZlZRIQLmFjczEuTWV0aG9kRmVlcxoWLmdvb2dsZS5wcm90b2J1Zi5F",
            "bXB0eSIAEkUKGUNoYW5nZU1ldGhvZEZlZUNvbnRyb2xsZXISDi5BdXRob3Jp",
            "dHlJbmZvGhYuZ29vZ2xlLnByb3RvYnVmLkVtcHR5IgASRQoMR2V0TWV0aG9k",
            "RmVlEhwuZ29vZ2xlLnByb3RvYnVmLlN0cmluZ1ZhbHVlGhAuYWNzMS5NZXRo",
            "b2RGZWVzIgWIifcBARJHChZHZXRNZXRob2RGZWVDb250cm9sbGVyEhYuZ29v",
            "Z2xlLnByb3RvYnVmLkVtcHR5Gg4uQXV0aG9yaXR5SW5mbyIFiIn3AQFCH6oC",
            "E0FFbGYuU3RhbmRhcmRzLkFDUzGKkvQBBGFjczFQAFABUAJiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::AElf.OptionsReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.WrappersReflection.Descriptor, global::AElf.Types.CoreReflection.Descriptor, global::AuthorityInfoReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.Standards.ACS1.MethodFees), global::AElf.Standards.ACS1.MethodFees.Parser, new[]{ "MethodName", "Fees", "IsSizeFeeFree" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.Standards.ACS1.MethodFee), global::AElf.Standards.ACS1.MethodFee.Parser, new[]{ "Symbol", "BasicFee" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.Standards.ACS1.MethodFeeSet), global::AElf.Standards.ACS1.MethodFeeSet.Parser, new[]{ "Method", "Symbol", "OldFee", "NewFee" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class MethodFees : pb::IMessage<MethodFees>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<MethodFees> _parser = new pb::MessageParser<MethodFees>(() => new MethodFees());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<MethodFees> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.Standards.ACS1.Acs1Reflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public MethodFees() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public MethodFees(MethodFees other) : this() {
      methodName_ = other.methodName_;
      fees_ = other.fees_.Clone();
      isSizeFeeFree_ = other.isSizeFeeFree_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public MethodFees Clone() {
      return new MethodFees(this);
    }

    /// <summary>Field number for the "method_name" field.</summary>
    public const int MethodNameFieldNumber = 1;
    private string methodName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string MethodName {
      get { return methodName_; }
      set {
        methodName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "fees" field.</summary>
    public const int FeesFieldNumber = 2;
    private static readonly pb::FieldCodec<global::AElf.Standards.ACS1.MethodFee> _repeated_fees_codec
        = pb::FieldCodec.ForMessage(18, global::AElf.Standards.ACS1.MethodFee.Parser);
    private readonly pbc::RepeatedField<global::AElf.Standards.ACS1.MethodFee> fees_ = new pbc::RepeatedField<global::AElf.Standards.ACS1.MethodFee>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::AElf.Standards.ACS1.MethodFee> Fees {
      get { return fees_; }
    }

    /// <summary>Field number for the "is_size_fee_free" field.</summary>
    public const int IsSizeFeeFreeFieldNumber = 3;
    private bool isSizeFeeFree_;
    /// <summary>
    /// Optional based on the implementation of SetMethodFee method.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool IsSizeFeeFree {
      get { return isSizeFeeFree_; }
      set {
        isSizeFeeFree_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as MethodFees);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(MethodFees other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MethodName != other.MethodName) return false;
      if(!fees_.Equals(other.fees_)) return false;
      if (IsSizeFeeFree != other.IsSizeFeeFree) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (MethodName.Length != 0) hash ^= MethodName.GetHashCode();
      hash ^= fees_.GetHashCode();
      if (IsSizeFeeFree != false) hash ^= IsSizeFeeFree.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (MethodName.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(MethodName);
      }
      fees_.WriteTo(output, _repeated_fees_codec);
      if (IsSizeFeeFree != false) {
        output.WriteRawTag(24);
        output.WriteBool(IsSizeFeeFree);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (MethodName.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(MethodName);
      }
      fees_.WriteTo(ref output, _repeated_fees_codec);
      if (IsSizeFeeFree != false) {
        output.WriteRawTag(24);
        output.WriteBool(IsSizeFeeFree);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (MethodName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(MethodName);
      }
      size += fees_.CalculateSize(_repeated_fees_codec);
      if (IsSizeFeeFree != false) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(MethodFees other) {
      if (other == null) {
        return;
      }
      if (other.MethodName.Length != 0) {
        MethodName = other.MethodName;
      }
      fees_.Add(other.fees_);
      if (other.IsSizeFeeFree != false) {
        IsSizeFeeFree = other.IsSizeFeeFree;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            MethodName = input.ReadString();
            break;
          }
          case 18: {
            fees_.AddEntriesFrom(input, _repeated_fees_codec);
            break;
          }
          case 24: {
            IsSizeFeeFree = input.ReadBool();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            MethodName = input.ReadString();
            break;
          }
          case 18: {
            fees_.AddEntriesFrom(ref input, _repeated_fees_codec);
            break;
          }
          case 24: {
            IsSizeFeeFree = input.ReadBool();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class MethodFee : pb::IMessage<MethodFee>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<MethodFee> _parser = new pb::MessageParser<MethodFee>(() => new MethodFee());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<MethodFee> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.Standards.ACS1.Acs1Reflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public MethodFee() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public MethodFee(MethodFee other) : this() {
      symbol_ = other.symbol_;
      basicFee_ = other.basicFee_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public MethodFee Clone() {
      return new MethodFee(this);
    }

    /// <summary>Field number for the "symbol" field.</summary>
    public const int SymbolFieldNumber = 1;
    private string symbol_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Symbol {
      get { return symbol_; }
      set {
        symbol_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "basic_fee" field.</summary>
    public const int BasicFeeFieldNumber = 2;
    private long basicFee_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public long BasicFee {
      get { return basicFee_; }
      set {
        basicFee_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as MethodFee);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(MethodFee other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Symbol != other.Symbol) return false;
      if (BasicFee != other.BasicFee) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Symbol.Length != 0) hash ^= Symbol.GetHashCode();
      if (BasicFee != 0L) hash ^= BasicFee.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Symbol.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Symbol);
      }
      if (BasicFee != 0L) {
        output.WriteRawTag(16);
        output.WriteInt64(BasicFee);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Symbol.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Symbol);
      }
      if (BasicFee != 0L) {
        output.WriteRawTag(16);
        output.WriteInt64(BasicFee);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Symbol.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Symbol);
      }
      if (BasicFee != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(BasicFee);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(MethodFee other) {
      if (other == null) {
        return;
      }
      if (other.Symbol.Length != 0) {
        Symbol = other.Symbol;
      }
      if (other.BasicFee != 0L) {
        BasicFee = other.BasicFee;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Symbol = input.ReadString();
            break;
          }
          case 16: {
            BasicFee = input.ReadInt64();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Symbol = input.ReadString();
            break;
          }
          case 16: {
            BasicFee = input.ReadInt64();
            break;
          }
        }
      }
    }
    #endif

  }

  /// <summary>
  /// Events
  /// </summary>
  public sealed partial class MethodFeeSet : pb::IMessage<MethodFeeSet>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<MethodFeeSet> _parser = new pb::MessageParser<MethodFeeSet>(() => new MethodFeeSet());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<MethodFeeSet> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.Standards.ACS1.Acs1Reflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public MethodFeeSet() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public MethodFeeSet(MethodFeeSet other) : this() {
      method_ = other.method_;
      symbol_ = other.symbol_;
      oldFee_ = other.oldFee_;
      newFee_ = other.newFee_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public MethodFeeSet Clone() {
      return new MethodFeeSet(this);
    }

    /// <summary>Field number for the "method" field.</summary>
    public const int MethodFieldNumber = 1;
    private string method_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Method {
      get { return method_; }
      set {
        method_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "symbol" field.</summary>
    public const int SymbolFieldNumber = 2;
    private string symbol_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Symbol {
      get { return symbol_; }
      set {
        symbol_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "old_fee" field.</summary>
    public const int OldFeeFieldNumber = 3;
    private long oldFee_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public long OldFee {
      get { return oldFee_; }
      set {
        oldFee_ = value;
      }
    }

    /// <summary>Field number for the "new_fee" field.</summary>
    public const int NewFeeFieldNumber = 4;
    private long newFee_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public long NewFee {
      get { return newFee_; }
      set {
        newFee_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as MethodFeeSet);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(MethodFeeSet other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Method != other.Method) return false;
      if (Symbol != other.Symbol) return false;
      if (OldFee != other.OldFee) return false;
      if (NewFee != other.NewFee) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Method.Length != 0) hash ^= Method.GetHashCode();
      if (Symbol.Length != 0) hash ^= Symbol.GetHashCode();
      if (OldFee != 0L) hash ^= OldFee.GetHashCode();
      if (NewFee != 0L) hash ^= NewFee.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Method.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Method);
      }
      if (Symbol.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Symbol);
      }
      if (OldFee != 0L) {
        output.WriteRawTag(24);
        output.WriteInt64(OldFee);
      }
      if (NewFee != 0L) {
        output.WriteRawTag(32);
        output.WriteInt64(NewFee);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Method.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Method);
      }
      if (Symbol.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Symbol);
      }
      if (OldFee != 0L) {
        output.WriteRawTag(24);
        output.WriteInt64(OldFee);
      }
      if (NewFee != 0L) {
        output.WriteRawTag(32);
        output.WriteInt64(NewFee);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Method.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Method);
      }
      if (Symbol.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Symbol);
      }
      if (OldFee != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(OldFee);
      }
      if (NewFee != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(NewFee);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(MethodFeeSet other) {
      if (other == null) {
        return;
      }
      if (other.Method.Length != 0) {
        Method = other.Method;
      }
      if (other.Symbol.Length != 0) {
        Symbol = other.Symbol;
      }
      if (other.OldFee != 0L) {
        OldFee = other.OldFee;
      }
      if (other.NewFee != 0L) {
        NewFee = other.NewFee;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Method = input.ReadString();
            break;
          }
          case 18: {
            Symbol = input.ReadString();
            break;
          }
          case 24: {
            OldFee = input.ReadInt64();
            break;
          }
          case 32: {
            NewFee = input.ReadInt64();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            Method = input.ReadString();
            break;
          }
          case 18: {
            Symbol = input.ReadString();
            break;
          }
          case 24: {
            OldFee = input.ReadInt64();
            break;
          }
          case 32: {
            NewFee = input.ReadInt64();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
