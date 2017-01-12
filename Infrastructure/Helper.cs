namespace Infrastructure
{
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Text;

    public static class Helper
    {
        /// <summary>
        /// 根据角色标识转换为角色名称 [已弃用]
        /// 明明用户列表中还在用呢
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <returns></returns>
        public static string RoleIdToName(string roleId)
        {
            var dic = new Dictionary<string, string> {
                { "BB42BEE1-05A4-E611-80C5-507B9DE4A488", "系统管理员" },
                { "BC42BEE1-05A4-E611-80C5-507B9DE4A488", "管理员" },
                { "BD42BEE1-05A4-E611-80C5-507B9DE4A488", "初审员" },
                { "BE42BEE1-05A4-E611-80C5-507B9DE4A488", "复审员" },
                { "BF42BEE1-05A4-E611-80C5-507B9DE4A488", "运营初审" },
                { "C042BEE1-05A4-E611-80C5-507B9DE4A488", "运营复审" },
                { "C142BEE1-05A4-E611-80C5-507B9DE4A488", "财务" },
                { "C242BEE1-05A4-E611-80C5-507B9DE4A488", "总经理" },
                { "C342BEE1-05A4-E611-80C5-507B9DE4A488", "客户经理" },
                { "C442BEE1-05A4-E611-80C5-507B9DE4A488", "渠道经理" },
                { "C542BEE1-05A4-E611-80C5-507B9DE4A488", "出纳" },
                { "C642BEE1-05A4-E611-80C5-507B9DE4A488", "有权审核人" }

            };

            return dic[roleId];
        }

        /// <summary>
        /// 压缩打包
        /// </summary>
        /// <param name="files">内存流集合</param>
        /// <returns>内存流</returns>
        public static MemoryStream Compression(IDictionary<string, MemoryStream> files)
        {
            var stream = new MemoryStream();

            using (var archive = new ZipArchive(
                stream, ZipArchiveMode.Create, true, Encoding.GetEncoding("GB2312")))
            {
                foreach (var file in files)
                {
                    var filename = file.Key;
                    var buffer = file.Value.GetBuffer();
                    var entry = archive.CreateEntry(filename, CompressionLevel.Fastest);

                    using (var entryStream = entry.Open())
                    {
                        entryStream.Write(buffer, 0, buffer.Length);
                    }
                }
            }

            return stream;
        }
    }
}
