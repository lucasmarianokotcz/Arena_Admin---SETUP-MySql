namespace AcessoDados
{
	public class Conexao
    {
        //string de conexao ao BD
        private static string ConexaoMySql = @"Server=bmh6qyguc3q2m5pj55e9-mysql.services.clever-cloud.com;Database=bmh6qyguc3q2m5pj55e9;Uid=uyxmznkbb9o31umh;Pwd=B2r3ozXSEo6YengDgkDT;SslMode=none";

        public static string StringConexaoMySql
        {
            get { return ConexaoMySql; }
        }
    }
}
