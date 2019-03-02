﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:PocketHelp
	/// </summary>
	public partial class PocketHelp
	{
		public PocketHelp()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("helpId", "PocketHelp"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int helpId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PocketHelp");
			strSql.Append(" where helpId=@helpId");
			SqlParameter[] parameters = {
					new SqlParameter("@helpId", SqlDbType.Int,4)
			};
			parameters[0].Value = helpId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.PocketHelp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PocketHelp(");
			strSql.Append("HelpTitle,HelpInfo)");
			strSql.Append(" values (");
			strSql.Append("@HelpTitle,@HelpInfo)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@HelpTitle", SqlDbType.VarChar,50),
					new SqlParameter("@HelpInfo", SqlDbType.VarChar,1000)};
			parameters[0].Value = model.HelpTitle;
			parameters[1].Value = model.HelpInfo;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.PocketHelp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PocketHelp set ");
			strSql.Append("HelpTitle=@HelpTitle,");
			strSql.Append("HelpInfo=@HelpInfo");
			strSql.Append(" where helpId=@helpId");
			SqlParameter[] parameters = {
					new SqlParameter("@HelpTitle", SqlDbType.VarChar,50),
					new SqlParameter("@HelpInfo", SqlDbType.VarChar,1000),
					new SqlParameter("@helpId", SqlDbType.Int,4)};
			parameters[0].Value = model.HelpTitle;
			parameters[1].Value = model.HelpInfo;
			parameters[2].Value = model.helpId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int helpId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PocketHelp ");
			strSql.Append(" where helpId=@helpId");
			SqlParameter[] parameters = {
					new SqlParameter("@helpId", SqlDbType.Int,4)
			};
			parameters[0].Value = helpId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string helpIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PocketHelp ");
			strSql.Append(" where helpId in ("+helpIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.PocketHelp GetModel(int helpId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 helpId,HelpTitle,HelpInfo from PocketHelp ");
			strSql.Append(" where helpId=@helpId");
			SqlParameter[] parameters = {
					new SqlParameter("@helpId", SqlDbType.Int,4)
			};
			parameters[0].Value = helpId;

			Maticsoft.Model.PocketHelp model=new Maticsoft.Model.PocketHelp();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.PocketHelp DataRowToModel(DataRow row)
		{
			Maticsoft.Model.PocketHelp model=new Maticsoft.Model.PocketHelp();
			if (row != null)
			{
				if(row["helpId"]!=null && row["helpId"].ToString()!="")
				{
					model.helpId=int.Parse(row["helpId"].ToString());
				}
				if(row["HelpTitle"]!=null)
				{
					model.HelpTitle=row["HelpTitle"].ToString();
				}
				if(row["HelpInfo"]!=null)
				{
					model.HelpInfo=row["HelpInfo"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select helpId,HelpTitle,HelpInfo ");
			strSql.Append(" FROM PocketHelp ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" helpId,HelpTitle,HelpInfo ");
			strSql.Append(" FROM PocketHelp ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM PocketHelp ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.helpId desc");
			}
			strSql.Append(")AS Row, T.*  from PocketHelp T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "PocketHelp";
			parameters[1].Value = "helpId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

