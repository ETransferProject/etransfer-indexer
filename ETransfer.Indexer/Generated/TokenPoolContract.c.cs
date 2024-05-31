// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: token_pool_contract.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using System.Collections.Generic;
using aelf = global::AElf.CSharp.Core;

namespace ETransfer.Contracts.TokenPool {

  #region Events
  public partial class TokenPoolTransferred : aelf::IEvent<TokenPoolTransferred>
  {
    public global::System.Collections.Generic.IEnumerable<TokenPoolTransferred> GetIndexed()
    {
      return new List<TokenPoolTransferred>
      {
      };
    }

    public TokenPoolTransferred GetNonIndexed()
    {
      return new TokenPoolTransferred
      {
        Symbol = Symbol,
        Amount = Amount,
        From = From,
        To = To,
        ToChainId = ToChainId,
        ToAddress = ToAddress,
        MaxEstimateFee = MaxEstimateFee,
      };
    }
  }

  public partial class TokenPoolReleased : aelf::IEvent<TokenPoolReleased>
  {
    public global::System.Collections.Generic.IEnumerable<TokenPoolReleased> GetIndexed()
    {
      return new List<TokenPoolReleased>
      {
      };
    }

    public TokenPoolReleased GetNonIndexed()
    {
      return new TokenPoolReleased
      {
        Symbol = Symbol,
        Amount = Amount,
        From = From,
        To = To,
      };
    }
  }

  public partial class ReleaseControllerAdded : aelf::IEvent<ReleaseControllerAdded>
  {
    public global::System.Collections.Generic.IEnumerable<ReleaseControllerAdded> GetIndexed()
    {
      return new List<ReleaseControllerAdded>
      {
      };
    }

    public ReleaseControllerAdded GetNonIndexed()
    {
      return new ReleaseControllerAdded
      {
        Address = Address,
      };
    }
  }

  public partial class ReleaseControllerRemoved : aelf::IEvent<ReleaseControllerRemoved>
  {
    public global::System.Collections.Generic.IEnumerable<ReleaseControllerRemoved> GetIndexed()
    {
      return new List<ReleaseControllerRemoved>
      {
      };
    }

    public ReleaseControllerRemoved GetNonIndexed()
    {
      return new ReleaseControllerRemoved
      {
        Address = Address,
      };
    }
  }

  public partial class TokenPoolAdded : aelf::IEvent<TokenPoolAdded>
  {
    public global::System.Collections.Generic.IEnumerable<TokenPoolAdded> GetIndexed()
    {
      return new List<TokenPoolAdded>
      {
      };
    }

    public TokenPoolAdded GetNonIndexed()
    {
      return new TokenPoolAdded
      {
        Symbol = Symbol,
      };
    }
  }

  public partial class TokenHolderAdded : aelf::IEvent<TokenHolderAdded>
  {
    public global::System.Collections.Generic.IEnumerable<TokenHolderAdded> GetIndexed()
    {
      return new List<TokenHolderAdded>
      {
      };
    }

    public TokenHolderAdded GetNonIndexed()
    {
      return new TokenHolderAdded
      {
        Symbol = Symbol,
        TokenHolders = TokenHolders,
      };
    }
  }

  #endregion
  public static partial class TokenPoolContractContainer
  {
    static readonly string __ServiceName = "TokenPoolContract";

    #region Marshallers
    static readonly aelf::Marshaller<global::ETransfer.Contracts.TokenPool.InitializeInput> __Marshaller_InitializeInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ETransfer.Contracts.TokenPool.InitializeInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::ETransfer.Contracts.TokenPool.TransferTokenInput> __Marshaller_TransferTokenInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ETransfer.Contracts.TokenPool.TransferTokenInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::ETransfer.Contracts.TokenPool.ReleaseTokenInput> __Marshaller_ReleaseTokenInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ETransfer.Contracts.TokenPool.ReleaseTokenInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Types.Address> __Marshaller_aelf_Address = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Types.Address.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::ETransfer.Contracts.TokenPool.ControllerInput> __Marshaller_ControllerInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ETransfer.Contracts.TokenPool.ControllerInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::ETransfer.Contracts.TokenPool.WithdrawInput> __Marshaller_WithdrawInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ETransfer.Contracts.TokenPool.WithdrawInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::ETransfer.Contracts.TokenPool.AddTokenPoolInput> __Marshaller_AddTokenPoolInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ETransfer.Contracts.TokenPool.AddTokenPoolInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::ETransfer.Contracts.TokenPool.AddTokenHolderInput> __Marshaller_AddTokenHolderInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ETransfer.Contracts.TokenPool.AddTokenHolderInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::ETransfer.Contracts.TokenPool.ControllerOutput> __Marshaller_ControllerOutput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ETransfer.Contracts.TokenPool.ControllerOutput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::ETransfer.Contracts.TokenPool.GetPoolInfoInput> __Marshaller_GetPoolInfoInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ETransfer.Contracts.TokenPool.GetPoolInfoInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::ETransfer.Contracts.TokenPool.PoolInfo> __Marshaller_PoolInfo = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ETransfer.Contracts.TokenPool.PoolInfo.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::ETransfer.Contracts.TokenPool.TokenSymbolList> __Marshaller_TokenSymbolList = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ETransfer.Contracts.TokenPool.TokenSymbolList.Parser.ParseFrom);
    #endregion

    #region Methods
    static readonly aelf::Method<global::ETransfer.Contracts.TokenPool.InitializeInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_Initialize = new aelf::Method<global::ETransfer.Contracts.TokenPool.InitializeInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "Initialize",
        __Marshaller_InitializeInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::ETransfer.Contracts.TokenPool.TransferTokenInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_TransferToken = new aelf::Method<global::ETransfer.Contracts.TokenPool.TransferTokenInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "TransferToken",
        __Marshaller_TransferTokenInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::ETransfer.Contracts.TokenPool.ReleaseTokenInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_ReleaseToken = new aelf::Method<global::ETransfer.Contracts.TokenPool.ReleaseTokenInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "ReleaseToken",
        __Marshaller_ReleaseTokenInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElf.Types.Address, global::Google.Protobuf.WellKnownTypes.Empty> __Method_SetAdmin = new aelf::Method<global::AElf.Types.Address, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "SetAdmin",
        __Marshaller_aelf_Address,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::ETransfer.Contracts.TokenPool.ControllerInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_AddReleaseController = new aelf::Method<global::ETransfer.Contracts.TokenPool.ControllerInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "AddReleaseController",
        __Marshaller_ControllerInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::ETransfer.Contracts.TokenPool.ControllerInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_RemoveReleaseController = new aelf::Method<global::ETransfer.Contracts.TokenPool.ControllerInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "RemoveReleaseController",
        __Marshaller_ControllerInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::ETransfer.Contracts.TokenPool.WithdrawInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_Withdraw = new aelf::Method<global::ETransfer.Contracts.TokenPool.WithdrawInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "Withdraw",
        __Marshaller_WithdrawInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::ETransfer.Contracts.TokenPool.AddTokenPoolInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_AddTokenPool = new aelf::Method<global::ETransfer.Contracts.TokenPool.AddTokenPoolInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "AddTokenPool",
        __Marshaller_AddTokenPoolInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::ETransfer.Contracts.TokenPool.AddTokenHolderInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_AddTokenHolders = new aelf::Method<global::ETransfer.Contracts.TokenPool.AddTokenHolderInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "AddTokenHolders",
        __Marshaller_AddTokenHolderInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::AElf.Types.Address> __Method_GetAdmin = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::AElf.Types.Address>(
        aelf::MethodType.View,
        __ServiceName,
        "GetAdmin",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_aelf_Address);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::ETransfer.Contracts.TokenPool.ControllerOutput> __Method_GetReleaseControllers = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::ETransfer.Contracts.TokenPool.ControllerOutput>(
        aelf::MethodType.View,
        __ServiceName,
        "GetReleaseControllers",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_ControllerOutput);

    static readonly aelf::Method<global::ETransfer.Contracts.TokenPool.GetPoolInfoInput, global::ETransfer.Contracts.TokenPool.PoolInfo> __Method_GetPoolInfo = new aelf::Method<global::ETransfer.Contracts.TokenPool.GetPoolInfoInput, global::ETransfer.Contracts.TokenPool.PoolInfo>(
        aelf::MethodType.View,
        __ServiceName,
        "GetPoolInfo",
        __Marshaller_GetPoolInfoInput,
        __Marshaller_PoolInfo);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::ETransfer.Contracts.TokenPool.TokenSymbolList> __Method_GetSymbolTokens = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::ETransfer.Contracts.TokenPool.TokenSymbolList>(
        aelf::MethodType.View,
        __ServiceName,
        "GetSymbolTokens",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_TokenSymbolList);

    #endregion

    #region Descriptors
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::ETransfer.Contracts.TokenPool.TokenPoolContractReflection.Descriptor.Services[0]; }
    }

    public static global::System.Collections.Generic.IReadOnlyList<global::Google.Protobuf.Reflection.ServiceDescriptor> Descriptors
    {
      get
      {
        return new global::System.Collections.Generic.List<global::Google.Protobuf.Reflection.ServiceDescriptor>()
        {
          global::AElf.Standards.ACS12.Acs12Reflection.Descriptor.Services[0],
          global::ETransfer.Contracts.TokenPool.TokenPoolContractReflection.Descriptor.Services[0],
        };
      }
    }
    #endregion
  }
}
#endregion

