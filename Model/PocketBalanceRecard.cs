﻿using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// PocketBalanceRecard:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PocketBalanceRecard
	{
		public PocketBalanceRecard()
		{}
		#region Model
		private int _recardid;
		private string _recarduser;
		private string _recardmoney;
		private string _recardtime;
		/// <summary>
		/// 
		/// </summary>
		public int recardId
		{
			set{ _recardid=value;}
			get{return _recardid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string recardUser
		{
			set{ _recarduser=value;}
			get{return _recarduser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string recardMoney
		{
			set{ _recardmoney=value;}
			get{return _recardmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string recardTime
		{
			set{ _recardtime=value;}
			get{return _recardtime;}
		}
		#endregion Model

	}
}
