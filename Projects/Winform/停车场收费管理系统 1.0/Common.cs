using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 停车场项目
{
    /// <summary>
    /// 身份类型
    /// </summary>
    public enum Type
    {
        /// <summary>
        /// 会员
        /// </summary>
        nember,
        /// <summary>
        /// 临时
        /// </summary>
        temporary
    }
    /// <summary>
    /// 卡状态
    /// </summary>
    public enum State
    {
        /// <summary>
        /// 开户
        /// </summary>
        Openaccount,
        /// <summary>
        /// 未开户
        /// </summary>
        NotOpenaccount
    }
    /// <summary>
    /// 停车状态
    /// </summary>
    public enum ParkingState
    {
        /// <summary>
        /// 停车
        /// </summary>
        Parking,
        /// <summary>
        /// 未停车
        /// </summary>
        NotParking
    }
    class Common
    {

    }
}
