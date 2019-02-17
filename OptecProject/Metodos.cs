using System;

public class Class1
{
	
    public OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = U:\Optec\Optec.accdb");

    public DataTable SelectUsuario()
    {
        OleDbCommand comando = new OleDbCommand();
        comando.Connection = conexion;
        DataTable usuarios = new DataTable();
        comando.CommandText = "Select * FROM Usuario ORDER BY NombreCompleto";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);
        adaptador.Fill(usuarios);

        return usuarios;
    }
}

