namespace Data.PDF
{
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Text;
    using Infrastructure.PDF;
    using PDFPrint;

    public class CreatePdf
    {
        private Microsoft.Office.Interop.Word.Application app = null;
        private Microsoft.Office.Interop.Word.Document doc = null;
        private Microsoft.Office.Interop.Word.WdExportFormat wordPdf = Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF;
        private object missing = System.Reflection.Missing.Value;

        /// <summary>
        /// 远程转Pdf,并返回pdf保存路径
        /// </summary>
        /// <param name="newPath">新的pdf路径</param>
        /// <param name="fileName">合同模板名</param>
        /// <param name="param">参数</param>
        /// <param name="targetPdfName">需要生成的pdf的名字</param>
        /// <returns>路径</returns>
        public string TransformPdf(string newPath, string fileName, string param, string targetPdfName)
        {
            PathManager path = new PathManager();

            // 模板
            object oldPath = path.GetTemplatePath() + fileName;

            // 新生成的
            object newPdfPath = path.GetPath(newPath) + targetPdfName + ".docx";
            WordHelper wordHelp = new WordHelper();

            // 判断该文件是否存在，存在就删除，否则同名文件生成会报错
            if (File.Exists(newPdfPath.ToString()))
            {
                File.Delete(newPdfPath.ToString());
            }

            File.Copy(oldPath.ToString(), newPdfPath.ToString());

            // 将要导出的新word文件名
            string physicNewFile = path.GetPath(newPath) + targetPdfName + ".pdf";

            try
            {
                // 判断该文件是否存在，存在就删除，否则同名文件生成会报错
                if (File.Exists(physicNewFile))
                {
                    File.Delete(physicNewFile);
                }

                // 处理成字典类型的占位符和数据
                var placeholder = BuildPlaceholder(param);

                // 创建word应用程序
                app = new Microsoft.Office.Interop.Word.Application();

                object missing = System.Reflection.Missing.Value;

                // 打开Word文档
                doc = app.Documents.Open(ref newPdfPath, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                object replace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
                foreach (var item in placeholder)
                {
                    app.Selection.Find.Replacement.ClearFormatting();
                    app.Selection.Find.ClearFormatting();

                    // 需要被替换的文本
                    app.Selection.Find.Text = item.Key;

                    // 替换文本 
                    app.Selection.Find.Replacement.Text = item.Value;

                    // 执行替换操作
                    app.Selection.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replace, ref missing, ref missing, ref missing, ref missing);
                }

                object objWdPdf = wordPdf;

                // 保存PDF文档
                doc.SaveAs(physicNewFile, objWdPdf, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
                doc.Close(ref this.missing, ref this.missing, ref this.missing);
                app.Quit(ref this.missing, ref this.missing, ref this.missing);
                File.Delete(newPdfPath.ToString());
            }
            catch
            {
                return null;
                //throw new Core.Exceptions.InvalidOperationAppException("合同生成失败.");
            }

            return physicNewFile;
        }

        /// <summary>
        /// 将占位符和数据处理成字典类型
        /// </summary>
        /// <param name="param">占位符和数</param>
        /// <returns></returns>
        public Dictionary<string, string> BuildPlaceholder(string param)
        {
            // 将获取的页面数据按'['进行分割
            string[] spilt = param.Split('&');

            // 构造数据，用于存放占位符数据
            Dictionary<string, string> placeholder = new Dictionary<string, string>();
            foreach (var item in spilt)
            {
                if (item.IndexOf('=') > -0)
                {
                    if (item.IndexOf('=') >= 0)
                    {
                        var x = item.Substring(0, item.IndexOf('='));
                        var y = item.Substring(item.IndexOf('=') + 1, item.Length - item.IndexOf('=') - 1);
                        if (string.IsNullOrEmpty(y))
                        {
                            y = y.PadLeft(x.Length, ' ');
                        }

                        placeholder.Add(x, y);
                    }
                }
            }

            return placeholder;
        }

        /// <summary>
        /// DataRow格式数据转成url参数
        /// </summary>
        /// wangpf  16.08.01
        /// <param name="dr">DataRow</param>
        /// <returns></returns>
        public string DataRowToParams(DataRow dr)
        {
            StringBuilder sb = new StringBuilder();

            DataTable dt = dr.Table;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append(dt.Columns[i].ColumnName);
                sb.Append("=");
                if (dt.Rows.Count > 0)
                {
                    sb.Append(dt.Rows[0][i].ToString());
                }

                sb.Append("&");
            }

            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }
    }
}
