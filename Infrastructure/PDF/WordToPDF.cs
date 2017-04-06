namespace Infrastructure.PDF
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;
    using PDFPrint;

    public class WordToPDF
    {
        public Dictionary<string, string> BuildSingleParams()
        {
            // 构造数据，用于存放占位符数据
            Dictionary<string, string> placeholder = new Dictionary<string, string>();

            placeholder.Add("[@姓名@]", "钟洪伟");
            placeholder.Add("[@证件号码@]", "339118199910245678");
            placeholder.Add("[@年@]", DateTime.Now.Year.ToString());
            placeholder.Add("[@月@]", DateTime.Now.Month.ToString());
            placeholder.Add("[@日@]", DateTime.Now.Day.ToString());

            return placeholder;
        }

        public string GetPath(string virtualPath)
        {
            string fullpath = HttpContext.Current.Server.MapPath(virtualPath);
            string directory = Directory.GetCurrentDirectory();
            if (!Directory.Exists(fullpath))
            {
                Directory.CreateDirectory(fullpath);
            }

            return fullpath;
        }

        public string TransformWordToPDF(object filePath, string pdfPath, Dictionary<string, string> param)
        {
            ////var path = GetPath(filePath);
            ////// 模板
            ////var wordPath = path+"\\Template\\" + fileName + ".docx" as object;
            ////var wordPath = @"D:\VS2017\git\ShrileFinance\UsedCarsFinance\Web\Contracts\" + fileName + ".docx";

            // 拷贝模板路径
            ////var copyWordPath = path + "\\Temps\\" + pdfName + ".docx" as object;
            ////copyWordPath = @"D:\VS2017\git\ShrileFinance\UsedCarsFinance\Web\upload\PDF\" + pdfName + ".docx";
            ////WordHelper wordHelp = new WordHelper();
            // 判断该文件是否存在，存在就删除，否则同名文件生成会报错
            ////if (File.Exists(copyWordPath.ToString()))
            ////{
            ////    File.Delete(copyWordPath.ToString());
            ////}

            ////File.Copy(wordPath.ToString(), copyWordPath.ToString());

            // 将要导出的pdf路径
            ////var pdfPath = filePath.Replace(".docx",".pdf");
            ////pdfPath = @"D:\VS2017\git\ShrileFinance\UsedCarsFinance\Web\upload\PDF\" + pdfName + ".pdf";

            // 判断该文件是否存在，存在就删除，否则同名文件生成会报错
            if (File.Exists(pdfPath))
            {
                File.Delete(pdfPath);
            }

            // 处理成字典类型的占位符和数据
            var placeholder = param;

            // 创建word应用程序
            var app = new Microsoft.Office.Interop.Word.Application();
            app.Visible = false;

            var missing = System.Reflection.Missing.Value as object;

            // 打开Word文档
            var doc = app.Documents.Open(ref filePath, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

            var replace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll as object;
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
                app.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsNone;
            }

            var objWdPdf = Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF as object;

            // 保存PDF文档
            doc.SaveAs(pdfPath, objWdPdf, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            ////wordHelp.Close();
            doc.Close(ref missing, ref missing, ref missing);
            app.Quit(ref missing, ref missing, ref missing);
            ////File.Delete(copyWordPath.ToString());            

            return pdfPath;
        }

        public string CopyWord(string filePath, string fileName, string pdfName)
        {
            PathManager path = new PathManager();

            // 模板
            object oldPath = path.GetTemplatePath() + fileName;

            // 新生成的
            object newPdfPath = path.GetPath(filePath) + pdfName + ".docx";

            // 判断该文件是否存在，存在就删除，否则同名文件生成会报错
            if (File.Exists(newPdfPath.ToString()))
            {
                File.Delete(newPdfPath.ToString());
            }

            File.Copy(oldPath.ToString(), newPdfPath.ToString());

            return newPdfPath.ToString();
        }
    }
}
