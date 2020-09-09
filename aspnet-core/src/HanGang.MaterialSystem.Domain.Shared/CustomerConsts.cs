using System;
using System.Collections.Generic;
using System.Text;

namespace HanGang.MaterialSystem
{
    public static class CustomerConsts
    {
        #region 默认长度
        public const int MaxLength32 = 32;
        public const int MaxLength64 = 64;
        public const int MaxLength128 = 128;
        public const int MaxLength256 = 256;
        public const int MaxLength512 = 512;
        #endregion

        #region 系统默认
        public const string AppName = "NetCore";

        public const string LocalizationSourceName = "NetCore";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;//禁用多租户false

        #endregion

        #region 默认格式

        public const string DateFormatString = "yyyy/MM/dd";
        public const string DateTimeFormatString = "yyyy/MM/dd hh:mm:ss";

        #endregion

        public const string DefaultDbTablePrefix = "Material_";

        public const string DefaultDbSchema = "hangang";

        public const int MaxEmailAddressLength = 256;

        public const int MaxPlainPasswordLength = 32;

        /// <summary>
        ///     Default page size for paged requests.
        /// </summary>
        public const int DefaultPageSize = 1000;

        /// <summary>
        ///     Maximum allowed page size for paged requests.
        /// </summary>
        public const int MaxPageSize = int.MaxValue;

        /// <summary>
        ///     默认排序
        /// </summary>
        public const string DefaultSorting = "CreationTime desc";

        /// <summary>
        ///     随机数最大值.六位数
        /// </summary>
        public const int MinNumber = 100000;

        /// <summary>
        ///     随机数最大值.六位数
        /// </summary>
        public const int MaxNumber = 999999;
    }
}
