namespace Core.Entities.Flow
{
    public enum FormStateEnum : byte
    {
        //// 全部禁用
        禁用 = 0,
        //// 不禁用
        状态1 = 1,
        //// 部分禁用
        状态2 = 2,
        //// 当状态为3时表示还款
        状态3 = 3
    }
}
