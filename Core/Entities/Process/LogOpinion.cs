namespace Core.Entities.Process
{
    /// <summary>
    /// 审核意见
    /// </summary>
    public class AuditOpinion
    {
        // 内部意见
        public string InternalOpinion { get; set; }

        // 意见
        public string ExnernalOpinion { get; set; }
    }
}
