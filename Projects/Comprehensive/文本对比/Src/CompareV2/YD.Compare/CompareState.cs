/// <summary>
/// 比较状态
/// </summary>
public enum CompareState
{
    /// <summary>
    /// 未知，未经过比较
    /// </summary>
    UnKnows = 0,
    /// <summary>
    /// 两行相同
    /// </summary>
    Same = 1,
    /// <summary>
    /// 两行有差别
    /// </summary>
    Different = 2,
    /// <summary>
    /// 新插入的行
    /// </summary>
    Insert = 3,
    /// <summary>
    /// 被删除的行
    /// </summary>
    Delete = 4,
}