using Assets.Scripts.Common;
using System;
using tsf4g_tdr_csharp;

namespace CSProtocol
{
	public class COMDT_CHAT_MSG_INBATTLE : ProtocolObject
	{
		public COMDT_INBAT_CHAT_PLAYER_INFO stFrom;

		public byte bChatType;

		public COMDT_INBATTLE_CHAT_UNION stChatInfo;

		public static readonly uint BASEVERSION = 1u;

		public static readonly uint CURRVERSION = 1u;

		public static readonly int CLASS_ID = 290;

		public COMDT_CHAT_MSG_INBATTLE()
		{
			this.stFrom = (COMDT_INBAT_CHAT_PLAYER_INFO)ProtocolObjectPool.Get(COMDT_INBAT_CHAT_PLAYER_INFO.CLASS_ID);
			this.stChatInfo = (COMDT_INBATTLE_CHAT_UNION)ProtocolObjectPool.Get(COMDT_INBATTLE_CHAT_UNION.CLASS_ID);
		}

		public override TdrError.ErrorType construct()
		{
			return TdrError.ErrorType.TDR_NO_ERROR;
		}

		public TdrError.ErrorType pack(ref byte[] buffer, int size, ref int usedSize, uint cutVer)
		{
			if (buffer == null || buffer.GetLength(0) == 0 || size > buffer.GetLength(0))
			{
				return TdrError.ErrorType.TDR_ERR_INVALID_BUFFER_PARAMETER;
			}
			TdrWriteBuf tdrWriteBuf = ClassObjPool<TdrWriteBuf>.Get();
			tdrWriteBuf.set(ref buffer, size);
			TdrError.ErrorType errorType = this.pack(ref tdrWriteBuf, cutVer);
			if (errorType == TdrError.ErrorType.TDR_NO_ERROR)
			{
				buffer = tdrWriteBuf.getBeginPtr();
				usedSize = tdrWriteBuf.getUsedSize();
			}
			tdrWriteBuf.Release();
			return errorType;
		}

		public override TdrError.ErrorType pack(ref TdrWriteBuf destBuf, uint cutVer)
		{
			if (cutVer == 0u || COMDT_CHAT_MSG_INBATTLE.CURRVERSION < cutVer)
			{
				cutVer = COMDT_CHAT_MSG_INBATTLE.CURRVERSION;
			}
			if (COMDT_CHAT_MSG_INBATTLE.BASEVERSION > cutVer)
			{
				return TdrError.ErrorType.TDR_ERR_CUTVER_TOO_SMALL;
			}
			TdrError.ErrorType errorType = this.stFrom.pack(ref destBuf, cutVer);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = destBuf.writeUInt8(this.bChatType);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			long selector = (long)this.bChatType;
			errorType = this.stChatInfo.pack(selector, ref destBuf, cutVer);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			return errorType;
		}

		public TdrError.ErrorType unpack(ref byte[] buffer, int size, ref int usedSize, uint cutVer)
		{
			if (buffer == null || buffer.GetLength(0) == 0 || size > buffer.GetLength(0))
			{
				return TdrError.ErrorType.TDR_ERR_INVALID_BUFFER_PARAMETER;
			}
			TdrReadBuf tdrReadBuf = ClassObjPool<TdrReadBuf>.Get();
			tdrReadBuf.set(ref buffer, size);
			TdrError.ErrorType result = this.unpack(ref tdrReadBuf, cutVer);
			usedSize = tdrReadBuf.getUsedSize();
			tdrReadBuf.Release();
			return result;
		}

		public override TdrError.ErrorType unpack(ref TdrReadBuf srcBuf, uint cutVer)
		{
			if (cutVer == 0u || COMDT_CHAT_MSG_INBATTLE.CURRVERSION < cutVer)
			{
				cutVer = COMDT_CHAT_MSG_INBATTLE.CURRVERSION;
			}
			if (COMDT_CHAT_MSG_INBATTLE.BASEVERSION > cutVer)
			{
				return TdrError.ErrorType.TDR_ERR_CUTVER_TOO_SMALL;
			}
			TdrError.ErrorType errorType = this.stFrom.unpack(ref srcBuf, cutVer);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			errorType = srcBuf.readUInt8(ref this.bChatType);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			long selector = (long)this.bChatType;
			errorType = this.stChatInfo.unpack(selector, ref srcBuf, cutVer);
			if (errorType != TdrError.ErrorType.TDR_NO_ERROR)
			{
				return errorType;
			}
			return errorType;
		}

		public override int GetClassID()
		{
			return COMDT_CHAT_MSG_INBATTLE.CLASS_ID;
		}

		public override void OnRelease()
		{
			if (this.stFrom != null)
			{
				this.stFrom.Release();
				this.stFrom = null;
			}
			this.bChatType = 0;
			if (this.stChatInfo != null)
			{
				this.stChatInfo.Release();
				this.stChatInfo = null;
			}
		}

		public override void OnUse()
		{
			this.stFrom = (COMDT_INBAT_CHAT_PLAYER_INFO)ProtocolObjectPool.Get(COMDT_INBAT_CHAT_PLAYER_INFO.CLASS_ID);
			this.stChatInfo = (COMDT_INBATTLE_CHAT_UNION)ProtocolObjectPool.Get(COMDT_INBATTLE_CHAT_UNION.CLASS_ID);
		}
	}
}