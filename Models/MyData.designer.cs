﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagement.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="HotelManagement")]
	public partial class MyDataDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertStatusRoomType(StatusRoomType instance);
    partial void UpdateStatusRoomType(StatusRoomType instance);
    partial void DeleteStatusRoomType(StatusRoomType instance);
    partial void InsertRoomType(RoomType instance);
    partial void UpdateRoomType(RoomType instance);
    partial void DeleteRoomType(RoomType instance);
    #endregion
		
		public MyDataDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["HotelManagementConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MyDataDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MyDataDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MyDataDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MyDataDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<StatusRoomType> StatusRoomTypes
		{
			get
			{
				return this.GetTable<StatusRoomType>();
			}
		}
		
		public System.Data.Linq.Table<RoomType> RoomTypes
		{
			get
			{
				return this.GetTable<RoomType>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.StatusRoomType")]
	public partial class StatusRoomType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IDStatus;
		
		private string _StatusName;
		
		private System.Nullable<int> _IsAvtive;
		
		private EntitySet<RoomType> _RoomTypes;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDStatusChanging(int value);
    partial void OnIDStatusChanged();
    partial void OnStatusNameChanging(string value);
    partial void OnStatusNameChanged();
    partial void OnIsAvtiveChanging(System.Nullable<int> value);
    partial void OnIsAvtiveChanged();
    #endregion
		
		public StatusRoomType()
		{
			this._RoomTypes = new EntitySet<RoomType>(new Action<RoomType>(this.attach_RoomTypes), new Action<RoomType>(this.detach_RoomTypes));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDStatus", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int IDStatus
		{
			get
			{
				return this._IDStatus;
			}
			set
			{
				if ((this._IDStatus != value))
				{
					this.OnIDStatusChanging(value);
					this.SendPropertyChanging();
					this._IDStatus = value;
					this.SendPropertyChanged("IDStatus");
					this.OnIDStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusName", DbType="NVarChar(128)")]
		public string StatusName
		{
			get
			{
				return this._StatusName;
			}
			set
			{
				if ((this._StatusName != value))
				{
					this.OnStatusNameChanging(value);
					this.SendPropertyChanging();
					this._StatusName = value;
					this.SendPropertyChanged("StatusName");
					this.OnStatusNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsAvtive", DbType="Int")]
		public System.Nullable<int> IsAvtive
		{
			get
			{
				return this._IsAvtive;
			}
			set
			{
				if ((this._IsAvtive != value))
				{
					this.OnIsAvtiveChanging(value);
					this.SendPropertyChanging();
					this._IsAvtive = value;
					this.SendPropertyChanged("IsAvtive");
					this.OnIsAvtiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="StatusRoomType_RoomType", Storage="_RoomTypes", ThisKey="IDStatus", OtherKey="StatusRT")]
		public EntitySet<RoomType> RoomTypes
		{
			get
			{
				return this._RoomTypes;
			}
			set
			{
				this._RoomTypes.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_RoomTypes(RoomType entity)
		{
			this.SendPropertyChanging();
			entity.StatusRoomType = this;
		}
		
		private void detach_RoomTypes(RoomType entity)
		{
			this.SendPropertyChanging();
			entity.StatusRoomType = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.RoomType")]
	public partial class RoomType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IDRoomType;
		
		private string _RoomTypeName;
		
		private System.Nullable<int> _StatusRT;
		
		private EntityRef<StatusRoomType> _StatusRoomType;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDRoomTypeChanging(int value);
    partial void OnIDRoomTypeChanged();
    partial void OnRoomTypeNameChanging(string value);
    partial void OnRoomTypeNameChanged();
    partial void OnStatusRTChanging(System.Nullable<int> value);
    partial void OnStatusRTChanged();
    #endregion
		
		public RoomType()
		{
			this._StatusRoomType = default(EntityRef<StatusRoomType>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDRoomType", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IDRoomType
		{
			get
			{
				return this._IDRoomType;
			}
			set
			{
				if ((this._IDRoomType != value))
				{
					this.OnIDRoomTypeChanging(value);
					this.SendPropertyChanging();
					this._IDRoomType = value;
					this.SendPropertyChanged("IDRoomType");
					this.OnIDRoomTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoomTypeName", DbType="NVarChar(128)")]
		public string RoomTypeName
		{
			get
			{
				return this._RoomTypeName;
			}
			set
			{
				if ((this._RoomTypeName != value))
				{
					this.OnRoomTypeNameChanging(value);
					this.SendPropertyChanging();
					this._RoomTypeName = value;
					this.SendPropertyChanged("RoomTypeName");
					this.OnRoomTypeNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusRT", DbType="Int")]
		public System.Nullable<int> StatusRT
		{
			get
			{
				return this._StatusRT;
			}
			set
			{
				if ((this._StatusRT != value))
				{
					if (this._StatusRoomType.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnStatusRTChanging(value);
					this.SendPropertyChanging();
					this._StatusRT = value;
					this.SendPropertyChanged("StatusRT");
					this.OnStatusRTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="StatusRoomType_RoomType", Storage="_StatusRoomType", ThisKey="StatusRT", OtherKey="IDStatus", IsForeignKey=true)]
		public StatusRoomType StatusRoomType
		{
			get
			{
				return this._StatusRoomType.Entity;
			}
			set
			{
				StatusRoomType previousValue = this._StatusRoomType.Entity;
				if (((previousValue != value) 
							|| (this._StatusRoomType.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._StatusRoomType.Entity = null;
						previousValue.RoomTypes.Remove(this);
					}
					this._StatusRoomType.Entity = value;
					if ((value != null))
					{
						value.RoomTypes.Add(this);
						this._StatusRT = value.IDStatus;
					}
					else
					{
						this._StatusRT = default(Nullable<int>);
					}
					this.SendPropertyChanged("StatusRoomType");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
