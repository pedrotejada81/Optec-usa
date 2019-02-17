using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public class Metodo
{
    static DataTable feriados;

    //public OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\Optec\Optec\Optec.mdb");
    //public OleDbConnection conexionScanner = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = c:\Optec\Optec\Att2000.mdb");
    public OleDbConnection conexionScanner = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = U:\Optec\Optec\att\att2000.mdb");
    public OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = U:\Optec\Optec\Optec.mdb");
    //public OleDbConnection conexionScanner = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = U:\Optec\Optec\Att2000.mdb");

    public string ruta = @"U:\Optec\Optec\Optec\";

    public DataTable SelectUsuario()
    {
        OleDbCommand comando = new OleDbCommand();
        comando.Connection = conexion;
        DataTable usuarios = new DataTable();
        comando.CommandText = "Select * FROM Usuario ORDER BY NombreCompleto";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);

        conexion.Open();
        adaptador.Fill(usuarios);
        conexion.Close();
        return usuarios;
    }

    public DataTable SelectLogin (string Usuario, String Contraseña)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;
        cmd.Parameters.AddWithValue("@Usuario", Usuario);
        cmd.Parameters.AddWithValue("@Contraseña", Contraseña);
        DataTable tabla = new DataTable();
        cmd.CommandText = "SELECT * FROM Usuario WHERE Usuario=@Usuario AND Contraseña=@Contraseña";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(cmd);

        conexion.Open();
        adaptador.Fill(tabla);
        conexion.Close();
        return tabla;
    }

    public DataTable SelectEmpleado(int Id)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;
        cmd.Parameters.AddWithValue("@Id", Id);
       
        DataTable tabla = new DataTable();
        cmd.CommandText = "SELECT * FROM Empleado WHERE Id=@Id";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(cmd);

        conexion.Open();
        adaptador.Fill(tabla);
        conexion.Close();

        return tabla;
    }

    public DataTable SelectTodosEmpleados()
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;
        DataTable tabla = new DataTable();
        cmd.CommandText = "SELECT * FROM Empleado";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(cmd);

        conexion.Open();
        adaptador.Fill(tabla);
        conexion.Close();

        return tabla;
    }

    public void InsertarDepartamento(string Departamento)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;
        cmd.Parameters.AddWithValue("@Usuario", Departamento);        
        DataTable tabla = new DataTable();
        cmd.CommandText = "INSERT INTO Departamento (Departamento) VALUES (@Departamento)";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(cmd);

        conexion.Open();
        cmd.ExecuteNonQuery();
        conexion.Close();       
    }

    public DataTable SelectDepartamento()
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;        
        DataTable tabla = new DataTable();
        cmd.CommandText = "SELECT * FROM Departamento ORDER BY Id";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(cmd);

        conexion.Open();
        adaptador.Fill(tabla);
        conexion.Close();
        return tabla;
    }

    public void ModificarDepartamento(int Id, string Departamento)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;        
        cmd.Parameters.AddWithValue("@Departamento", Departamento);        
        cmd.Parameters.AddWithValue("@Id", Id);

        cmd.CommandText = "UPDATE Departamento SET Departamento=@Departamento WHERE Id=@Id";
        conexion.Open();
        cmd.ExecuteNonQuery();
        conexion.Close();
    }

    public void ModificarSubdepartamento(int Id, string Subdepartamento)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;
        cmd.Parameters.AddWithValue("@Subdepartamento", Subdepartamento);
        cmd.Parameters.AddWithValue("@Id", Id);

        cmd.CommandText = "UPDATE SubDepartamento SET SubDepartamento=@SubDepartamento WHERE Id=@Id";
        conexion.Open();
        cmd.ExecuteNonQuery();
        conexion.Close();
    }

    public void EliminarDepartamento(int Id)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;        
        cmd.Parameters.AddWithValue("@Id", Id);

        cmd.CommandText = "DELETE FROM Departamento WHERE Id=@Id";
        conexion.Open();
        cmd.ExecuteNonQuery();
        conexion.Close();
    }

    public void EliminarSubdepartamento(int Id)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;
        cmd.Parameters.AddWithValue("@Id", Id);

        cmd.CommandText = "DELETE FROM SubDepartamento WHERE Id=@Id";
        conexion.Open();
        cmd.ExecuteNonQuery();
        conexion.Close();
    }

    public void InsertarSubdepartamento(string SubDepartamento, int IdDepartamento)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;
        
        cmd.Parameters.AddWithValue("@SubDepartamento", SubDepartamento);
        cmd.Parameters.AddWithValue("@IdDepartamento", IdDepartamento);
        DataTable tabla = new DataTable();
        cmd.CommandText = "INSERT INTO SubDepartamento ( SubDepartamento,IdDepartamento) VALUES (@SubDepartamento, @IdDepartamento)";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(cmd);

        conexion.Open();
        cmd.ExecuteNonQuery();
        conexion.Close();
    }

    public DataTable SelectSubdepartamento(int IdDepartamento)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;
        cmd.Parameters.AddWithValue("@IdDepartamento", IdDepartamento);
        DataTable tabla = new DataTable();
        cmd.CommandText = "SELECT * FROM SubDepartamento WHERE IdDepartamento=@IdDepartamento";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(cmd);

        conexion.Open();
        adaptador.Fill(tabla);
        conexion.Close();

        return tabla;
    }

    public DataTable SelectTodosSubdpto()
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;        
        DataTable tabla = new DataTable();
        cmd.CommandText = "SELECT * FROM SubDepartamento";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(cmd);

        conexion.Open();
        adaptador.Fill(tabla);
        conexion.Close();

        return tabla;
    }

    public void InsertarEmpleado(string Nombre, string Apellido, string Documento, string Cedula, string Telefono, string Celular, string Direccion,
                                 string Contacto, string Contacto2, string Departamento, string Subdepartamento, string Puesto, string Igualado, DateTime Fentrada, DateTime Fsalida, string Cuenta, Boolean Habilitado, double Salario)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;

        cmd.Parameters.AddWithValue("@Nombre", Nombre);
        cmd.Parameters.AddWithValue("@Apellido", Apellido);
        cmd.Parameters.AddWithValue("@Documento", Documento);
        cmd.Parameters.AddWithValue("@Cedula", Cedula);
        cmd.Parameters.AddWithValue("@Telefono", Telefono);
        cmd.Parameters.AddWithValue("@Celular", Celular);
        cmd.Parameters.AddWithValue("@Direccion", Direccion);
        cmd.Parameters.AddWithValue("@Contacto", Contacto);
        cmd.Parameters.AddWithValue("@Contacto2", Contacto2);
        cmd.Parameters.AddWithValue("@Departamento", Departamento);
        cmd.Parameters.AddWithValue("@Subdepartamento", Subdepartamento);
        cmd.Parameters.AddWithValue("@Puesto", Puesto);
        cmd.Parameters.AddWithValue("@Igualado", Igualado);
        cmd.Parameters.AddWithValue("@Fentrada", Fentrada);
        cmd.Parameters.AddWithValue("@Fsalida", Fsalida);
        cmd.Parameters.AddWithValue("@Cuenta", Cuenta);
        cmd.Parameters.AddWithValue("@Habilitado", Habilitado);
        cmd.Parameters.AddWithValue("@Salario", Salario);
        DataTable tabla = new DataTable();
        cmd.CommandText = "INSERT INTO Empleado (Nombre, Apellido, Documento, Cedula, Telefono, Celular, Direccion, Contacto, Contacto2, Departamento, Subdepartamento, Puesto, Igualado, FechaEntrada, FechaSalida, NumeroCuenta, Habilitado, SalarioMensual) VALUES (@Nombre, @Apellido, @Documento, @Cedula, @Telefono, @Celular, @Direccion, @Contacto, @Contacto2, @Departamento, @Subdepartamento, @Puesto, @Igualado, @Fentrada, @Fsalida, @Cuenta, @Habilitado, @Salario)";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(cmd);

        conexion.Open();
        cmd.ExecuteNonQuery();
        conexion.Close();
    }

    public DataTable TodosEmpleados() //samuel
    {
        OleDbCommand comando = new OleDbCommand();
        comando.Connection = conexion;
        DataTable dtEmpleados = new DataTable();
        comando.CommandText = "Select Id, Nombre, Apellido, Cedula, SalarioMensual AS Salario, Igualado FROM Empleado WHERE Habilitado=True ORDER BY Id";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);
        conexion.Open();
        adaptador.Fill(dtEmpleados);
        conexion.Close();

        return dtEmpleados;
    }

    
    public DataTable SelectHabilitado(bool Habilitado) 
    {
        OleDbCommand comando = new OleDbCommand();
        comando.Connection = conexion;
        comando.Parameters.AddWithValue("@Habilitado", Habilitado);
        DataTable dtEmpleados = new DataTable();
        comando.CommandText = "Select Id, Nombre, Apellido, Cedula, Telefono, Celular, Contacto, Contacto2, Departamento, SubDepartamento, Puesto, Habilitado FROM Empleado WHERE Habilitado=@Habilitado ORDER BY Id";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);

        conexion.Open();
        adaptador.Fill(dtEmpleados);
        conexion.Close();

        return dtEmpleados;
    }

    public DataTable dtBuscarPorFecha(int IdEmpleado, string Fecha1, string Fecha2) //samuel
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;
        cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
        cmd.Parameters.AddWithValue("@Fecha1", Fecha1);
        cmd.Parameters.AddWithValue("@Fecha2", Fecha2);
       
        cmd.CommandText = "SELECT * FROM Entrega where IdEmpleado=@IdEmpleado AND Fecha Between #" + Fecha1 + "# And #" + Fecha2 + "#";

        OleDbDataAdapter adap = new OleDbDataAdapter(cmd);
        DataTable dtEmpleados = new DataTable();

        conexion.Open();
        adap.Fill(dtEmpleados);
        conexion.Close();

        return dtEmpleados;
    }

    public void ModificarEmpleado (int Id, string Nombre, string Apellido, string Documento, string Cedula, string Telefono, string Celular, string Direccion, string Contacto, string Contacto2, 
                                    string  Departamento, string Subdepartamento, string Puesto, string Igualado, DateTime FechaEntrada, DateTime FechaSalida, string Cuenta, double SalarioMensual, 
                                    double Salarious, double Tasa)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;
        
        cmd.Parameters.AddWithValue("@Nombre", Nombre);
        cmd.Parameters.AddWithValue("@Apellido", Apellido);
        cmd.Parameters.AddWithValue("@Documento", Documento);
        cmd.Parameters.AddWithValue("@Cedula", Cedula);
        cmd.Parameters.AddWithValue("@Telefono", Telefono);
        cmd.Parameters.AddWithValue("@Celular", Celular);
        cmd.Parameters.AddWithValue("@Direccion", Direccion);
        cmd.Parameters.AddWithValue("@Contacto", Contacto);
        cmd.Parameters.AddWithValue("@Contacto2", Contacto2);
        cmd.Parameters.AddWithValue("@Departamento", Departamento);
        cmd.Parameters.AddWithValue("@Subdepartamento", Subdepartamento);
        cmd.Parameters.AddWithValue("@Puesto", Puesto);
        cmd.Parameters.AddWithValue("@Igualado", Igualado);
        cmd.Parameters.AddWithValue("@FechaEntrada", FechaEntrada);
        cmd.Parameters.AddWithValue("@FechaSalida", FechaSalida);
        cmd.Parameters.AddWithValue("@Cuenta", Cuenta);
        cmd.Parameters.AddWithValue("@SalarioMensual", SalarioMensual);
        cmd.Parameters.AddWithValue("@Salarious", Salarious);
        cmd.Parameters.AddWithValue("@Tasa", Tasa);
        cmd.Parameters.AddWithValue("@Id", Id);

        cmd.CommandText = "UPDATE Empleado SET Nombre=@Nombre, Apellido=@Apellido, Documento=@Documento, Cedula=@Cedula, Telefono=@Telefono, Celular=@Celular, Direccion=@Direccion, Contacto=@Contacto, Contacto2=@Contacto2, Departamento=@Departamento, Subdepartamento=@Subdepartamento, Puesto=@Puesto, Igualado=@Igualado, FechaEntrada=@FechaEntrada, FechaSalida=@FechaSalida, NumeroCuenta=@Cuenta, SalarioMensual=@SalarioMensual, Salarious=@Salarious, Tasa=@Tasa WHERE Id=@Id";
        conexion.Open();
        cmd.ExecuteNonQuery();
        conexion.Close();
    }

    public void InhabilitarEmpleado(int Id, string Nombre, string Apellido, string Puesto, DateTime FechaEntrada, DateTime FechaSalida, Boolean Habilitado)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;

        cmd.Parameters.AddWithValue("@Nombre", Nombre);
        cmd.Parameters.AddWithValue("@Apellido", Apellido);       
        cmd.Parameters.AddWithValue("@Puesto", Puesto);       
        cmd.Parameters.AddWithValue("@FechaEntrada", FechaEntrada);
        cmd.Parameters.AddWithValue("@FechaSalida", FechaSalida);
        cmd.Parameters.AddWithValue("@Habilitado", Habilitado);
        cmd.Parameters.AddWithValue("@Id", Id);

        cmd.CommandText = "UPDATE Empleado SET Nombre=@Nombre, Apellido=@Apellido, Puesto=@Puesto, FechaEntrada=@FechaEntrada, FechaSalida=@FechaSalida, Habilitado=@Habilitado WHERE Id=@Id";
        conexion.Open();
        cmd.ExecuteNonQuery();
        conexion.Close();
    }

    //Guardar Nomina por fecha
    public int GuardarNominaPorFecha(string FechaNomina, string Nota, string Semana, string FechaPrimeraNomina)
    {
        OleDbCommand comando = new OleDbCommand();
        comando.Parameters.AddWithValue("@FechaNomina", FechaNomina);
        comando.Parameters.AddWithValue("@Nota", Nota);
        comando.Parameters.AddWithValue("@Semana", Semana);
        comando.Parameters.AddWithValue("@FechaPrimeraNomina", FechaPrimeraNomina);


        comando.Connection = conexion;
        DataTable NominaPorFecha = new DataTable();
        comando.CommandText = "INSERT INTO NominaPorFecha (FechaNomina, Nota, Semana, FechaPrimeraNomina) VALUES(@FechaNomina, @Nota, @Semana, @FechaPrimeraNomina)";

        OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);



        string UltimoID = "Select @@Identity";
        int ID;

        conexion.Open();

        comando.ExecuteNonQuery();
        comando.CommandText = UltimoID;
        ID = (int)comando.ExecuteScalar();
        conexion.Close();
        return ID;

    }

    //Guarda la real nomina

    public string GuardarNomina(int IdFechaNomina, string FechaPrimeraNomina, string FechaDeNomina, int IdEmpleado, string Nombre, string Apellido, string Cedula, string Igualado, string Salario, string SalarioSemanal, string SalarioPorHora, string HorasOrdinarias, string HorasExtras, string HorasDobles, string DiasVacaciones, string MontoHorasOrdinarias, string MontoHorasExtras, string MontoHorasDobles, string Vacaciones, string Comisiones, string SueldoBruto, string AFP, string ARS, string OtrasDeducciones, string ISR, string TotalDeducciones, string SueldoNeto, string TSS, string Extras) //Guarda La Nomina Depurada
    {
        OleDbCommand comando = new OleDbCommand();
        comando.Parameters.AddWithValue("@IdFechaNomina", IdFechaNomina);
        comando.Parameters.AddWithValue("@FechaPrimeraNomina", FechaPrimeraNomina);
        comando.Parameters.AddWithValue("@FechaDeNomina", FechaDeNomina);
        comando.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
        comando.Parameters.AddWithValue("@Nombre", Nombre);
        comando.Parameters.AddWithValue("@Apellido", Apellido);
        comando.Parameters.AddWithValue("@Cedula", Cedula);
        comando.Parameters.AddWithValue("@Igualado", Igualado);
        comando.Parameters.AddWithValue("@Salario", Salario);
        comando.Parameters.AddWithValue("@SalarioSemanal", SalarioSemanal);
        comando.Parameters.AddWithValue("@SalarioPorHora", SalarioPorHora);
        comando.Parameters.AddWithValue("@HorasOrdinarias", HorasOrdinarias);
        comando.Parameters.AddWithValue("@HorasExtras", HorasExtras);
        comando.Parameters.AddWithValue("@HorasDobles", HorasDobles);
        comando.Parameters.AddWithValue("@DiasVacaciones", DiasVacaciones);
        comando.Parameters.AddWithValue("@MontoHorasOrdinarias", MontoHorasOrdinarias);
        comando.Parameters.AddWithValue("@MontoHorasExtras", MontoHorasExtras);
        comando.Parameters.AddWithValue("@MontoHorasDobles", MontoHorasDobles);
        comando.Parameters.AddWithValue("@Vacaciones", Vacaciones);
        comando.Parameters.AddWithValue("@Comisiones", Comisiones);
        comando.Parameters.AddWithValue("@SueldoBruto", SueldoBruto);
        comando.Parameters.AddWithValue("@AFP", AFP);
        comando.Parameters.AddWithValue("@ARS", ARS);
        comando.Parameters.AddWithValue("@OtrasDeducciones", OtrasDeducciones);
        comando.Parameters.AddWithValue("@ISR", ISR);
        comando.Parameters.AddWithValue("@TotalDeducciones", TotalDeducciones);
        comando.Parameters.AddWithValue("@SueldoNeto", SueldoNeto);
        comando.Parameters.AddWithValue("@TSS", TSS);
        comando.Parameters.AddWithValue("@Extras", Extras);

        comando.Connection = conexion;
        DataTable Horas = new DataTable();
        comando.CommandText = "INSERT INTO Nomina (IdFechaNomina, FechaPrimeraNomina, FechaDeNomina, IdEmpleado, Nombre, Apellido, Cedula, Igualado, Salario, SalarioSemanal, SalarioHora, HorasOrdinarias, HorasExtras, HorasDobles, DiasVacaciones, MontoHorasOrdinarias, MontoHorasExtras, MontoHorasDobles, Vacaciones, Comisiones, SueldoBruto, AFP, ARS, OtrasDeducciones, ISR, TotalDeducciones, SueldoNeto, TSS, Extras) VALUES (@IdFechaNomina, @FechaPrimeraNomina, @FechaDeNomina, @IdEmpleado, @Nombre, @Apellido, @Cedula, @Igualado, @Salario, @SalarioSemanal, @SalarioHora, @HorasOrdinarias, @HorasExtras, @HorasDobles, @DiasVacaciones, @MontoHorasOrdinarias, @MontoHorasExtras, @MontoHorasDobles, @Vacaciones, @Comisiones, @SueldoBruto, @AFP, @ARS, @OtrasDeducciones, @ISR, @TotalDeducciones, @SueldoNeto, @TSS, @Extras)";
        //comando.CommandText = "INSERT INTO Nomina (IdFechaNomina, IdEmpleado, Nombre) VALUES (@IdFechaNomina, @IdEmpleado, @Nombre)";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);

        conexion.Open();
        comando.ExecuteNonQuery();
        conexion.Close();

        return "Nomina Guardada Correctamente";
    }

    //Guardar datos para la TSS
    public string GuardarTSS(int IdEmpleado, string Nombre, string Apellido, string Cedula, string MontoGlobal, string Extras)
    {
        OleDbCommand comando = new OleDbCommand();
        comando.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
        comando.Parameters.AddWithValue("@Nombre", Nombre);
        comando.Parameters.AddWithValue("@Apellido", Apellido);
        comando.Parameters.AddWithValue("@Cedula", Cedula);       
        comando.Parameters.AddWithValue("@MontoGlobal", MontoGlobal);
        comando.Parameters.AddWithValue("@Extras", Extras);

        comando.Connection = conexion;      
        comando.CommandText = "INSERT INTO TSS (IdEmpleado, Nombre, Apellido, Cedula, MontoGlobal, Extras) VALUES (@IdEmpleado, @Nombre, @Apellido, @Cedula, @MontoGlobal, @Extras)";       
        OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);

        conexion.Open();
        comando.ExecuteNonQuery();
        conexion.Close();

        return "Nomina Guardada Correctamente";
    }

    //Eliminar reporte TSS
    public void EliminarTSS()
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;       

        cmd.CommandText = "DELETE * FROM TSS";
        conexion.Open();
        cmd.ExecuteNonQuery();
        conexion.Close();
    }

    //agregar feriados
    public string AgregarFeriado(string Fecha)
    {
        OleDbCommand comando = new OleDbCommand();
        comando.Parameters.Add("@Fecha", OleDbType.DBDate).Value = DateTime.Parse(Fecha).ToShortDateString();
        comando.Connection = conexion;
        DataTable Horas = new DataTable();
        comando.CommandText = "Select Fecha FROM DiasFeriados WHERE Fecha = @Fecha";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);

        conexion.Open();
        adaptador.Fill(Horas);

        if (Horas != null)
        {
            if (Horas.Rows.Count > 0)
            {
                conexion.Close();
                return "Fecha ya habia sido agregada como feriado";
            }
        }
        comando.CommandText = "INSERT INTO DiasFeriados(Fecha) VALUES(@Fecha)";
        int i = comando.ExecuteNonQuery();
        if (i < 0)
        {
            conexion.Close();
            return "El dia feriado no fue agregado, por favor revise la lista y confirmar que no existe";
        }
        conexion.Close();
        return "El dia feriado fue agregado correctamente";
    }
    //borrar feriados
    public string BorrarFeriado(string Fecha)
    {
        OleDbCommand comando = new OleDbCommand();
        comando.Parameters.AddWithValue("@Fecha", Fecha);
        comando.Connection = conexion;
        comando.CommandText = "DELETE FROM DiasFeriados WHERE Fecha = @Fecha";

        conexion.Open();
        int i = comando.ExecuteNonQuery();
        conexion.Close();

        if (i < 0)
        {
            return "No se borro ningun dia";
        }

        return "El dia feriado fue borrado correctamente";
    }

    public DataTable ListaDeFeriados()
    {
        OleDbCommand comando = new OleDbCommand();
        comando.Connection = conexion;
        if (feriados == null)
        {
            feriados = new DataTable();
        }
        else
        {
            feriados.Clear();
        }
        comando.CommandText = "Select Fecha FROM DiasFeriados ORDER BY Fecha DESC";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);

        conexion.Open();
        adaptador.Fill(feriados);
        conexion.Close();
        return feriados;
    }

    public bool EsDiaFeriado(string Fecha)
    {
        if (feriados == null)
        {
            OleDbCommand comando = new OleDbCommand();
            comando.Parameters.Add("@Fecha", OleDbType.DBDate).Value = DateTime.Parse(Fecha).ToShortDateString();
            comando.Connection = conexion;
            feriados = new DataTable();
            comando.CommandText = "Select Fecha FROM DiasFeriados WHERE Fecha = @Fecha";
            OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);

            conexion.Open();
            adaptador.Fill(feriados);
            conexion.Close();
            if (feriados == null)
            {
                return false;
            }
            else if (feriados.Rows.Count < 1)
            {
                return false;
            }
            return true;
        }
        else
        {
            foreach (DataRow r in feriados.Rows) //este metodo da vueltas en la base de datos, chekeando los feriados, creo que la cosa esta por aqui
            {
                if (DateTime.Parse(r["Fecha"].ToString()).ToShortDateString().Equals(Fecha))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public DataTable SelectEmpleados()
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;

        DataTable tabla = new DataTable();
        cmd.CommandText = "SELECT * FROM Empleado";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(cmd);

        conexion.Open();
        adaptador.Fill(tabla);
        conexion.Close();

        return tabla;
    }

    public DataTable HorasTrabajadasEmpleados(int Id, string Fecha)
    {
        OleDbCommand comando = new OleDbCommand();
        comando.Parameters.AddWithValue("@Id", Id);
        comando.Parameters.AddWithValue("@Fecha", Fecha);
        comando.Connection = conexionScanner;
        DataTable Horas = new DataTable();
        comando.CommandText = "Select USERID, CHECKTIME FROM CHECKINOUT WHERE USERID = @Id AND CHECKTIME LIKE '" + Fecha + "'+'%'  ORDER BY CHECKTIME ASC";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);

        conexion.Open();
        adaptador.Fill(Horas);
        conexion.Close();

        return Horas;
    }

    public DataTable TSSPorFecha(string Fecha1, string Fecha2)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conexion;        
        cmd.Parameters.AddWithValue("@Fecha1", OleDbType.DBDate).Value = DateTime.Parse(Fecha1).ToShortDateString();
        cmd.Parameters.AddWithValue("@Fecha2", OleDbType.DBDate).Value = DateTime.Parse(Fecha2).ToShortDateString();      
        cmd.CommandText = "SELECT Nomina.IdEmpleado, Nomina.Nombre, Nomina.Apellido, Nomina.Cedula, Sum(Nomina.TSS) AS SumaDeTSS, Sum(Nomina.Extras)AS SumaDeExtras FROM Nomina WHERE FechaDeNomina BETWEEN @Fecha1 AND @Fecha2 GROUP BY Nomina.IdEmpleado, Nomina.Nombre, Nomina.Apellido, Nomina.Cedula";
        
        OleDbDataAdapter adap = new OleDbDataAdapter(cmd);
        DataTable dtID = new DataTable();

        conexion.Open();
        adap.Fill(dtID);
        conexion.Close();

        return dtID;       
    }

    //Nomina Por Fecha - Samuel
    public DataTable NominaPorFecha() 
    {
        OleDbCommand comando = new OleDbCommand();
        comando.Connection = conexion;
        DataTable Nominas = new DataTable();
        comando.CommandText = "Select IdFechaNomina, FechaDeNomina FROM Nomina GROUP BY FechaDeNomina, IdFechaNomina ORDER BY FechaDeNomina DESC";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);

        conexion.Open();
        adaptador.Fill(Nominas);
        conexion.Close();
        return Nominas;
    }

    public string ChekeoFecha(string Fecha) //Chekeo de Fecha para no repetir
    {
        try
        {
            OleDbCommand comando = new OleDbCommand();
            comando.Parameters.Add("@Fecha", OleDbType.DBDate).Value = DateTime.Parse(Fecha).ToShortDateString();
            comando.Connection = conexion;
            DataTable Horas = new DataTable();
            comando.CommandText = "Select FechaNomina FROM NominaPorFecha WHERE FechaNomina = @Fecha";
            OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            adaptador.Fill(Horas);

            if (Horas != null)
            {
                if (Horas.Rows.Count > 0)
                {
                    conexion.Close();
                    return "Fecha de nomina ya existe, por favor revisar";
                }
            }
            conexion.Close();
            return "Correcto";
        }
        catch(Exception ex)
        {
            conexion.Close();
            return ex.Message;
        }

    }

    //Actualizar Nomina

    public int ActualizarNomina(string idRow, int IdFechaNomina, int IdEmpleado, string Nombre, string Apellido, string Cedula, string Salario, string SalarioSemanal, string SalarioPorHora, string HorasOrdinarias, string HorasExtras, string HorasDobles, string DiasVacaciones, string MontoHorasOrdinarias, string MontoHorasExtras, string MontoHorasDobles, string Vacaciones, string Comisiones, string SueldoBruto, string AFP, string ARS, string OtrasDeducciones, string ISR, string TotalDeducciones, string SueldoNeto, string TSS, string Extras) //Guarda La Nomina Depurada
    {
        try
        {
            OleDbCommand comando = new OleDbCommand();

            
            comando.Parameters.AddWithValue("@HorasOrdinarias", HorasOrdinarias);
            comando.Parameters.AddWithValue("@HorasExtras", HorasExtras);
            comando.Parameters.AddWithValue("@HorasDobles", HorasDobles);
            comando.Parameters.AddWithValue("@DiasVacaciones", DiasVacaciones);
            comando.Parameters.AddWithValue("@MontoHorasOrdinarias", MontoHorasOrdinarias);
            comando.Parameters.AddWithValue("@MontoHorasExtras", MontoHorasExtras);
            comando.Parameters.AddWithValue("@MontoHorasDobles", MontoHorasDobles);
            comando.Parameters.AddWithValue("@Vacaciones", Vacaciones);
            comando.Parameters.AddWithValue("@Comisiones", Comisiones);
            comando.Parameters.AddWithValue("@SueldoBruto", SueldoBruto);
            comando.Parameters.AddWithValue("@AFP", AFP);
            comando.Parameters.AddWithValue("@ARS", ARS);
            comando.Parameters.AddWithValue("@OtrasDeducciones", OtrasDeducciones);
            comando.Parameters.AddWithValue("@ISR", ISR);
            comando.Parameters.AddWithValue("@TotalDeducciones", TotalDeducciones);
            comando.Parameters.AddWithValue("@SueldoNeto", SueldoNeto);
            comando.Parameters.AddWithValue("@TSS", TSS);
            comando.Parameters.AddWithValue("@Extras", Extras);
            comando.Parameters.AddWithValue("@Id", idRow);
            comando.Connection = conexion;

            comando.CommandText = "UPDATE Nomina SET HorasOrdinarias=@HorasOrdinarias, HorasExtras=@HorasExtras, HorasDobles=@HorasDobles, DiasVacaciones=@DiasVacaciones, MontoHorasOrdinarias=@MontoHorasOrdinarias, MontoHorasExtras = @MontoHorasExtras, MontoHorasDobles =@MontoHorasDobles, Vacaciones=@Vacaciones, Comisiones=@Comisiones, SueldoBruto=@SueldoBruto, AFP=@AFP, ARS=@ARS, OtrasDeducciones=@OtrasDeducciones, ISR=@ISR, TotalDeducciones=@TotalDeducciones, SueldoNeto=@SueldoNeto,TSS=@TSS,Extras=@Extras WHERE Id=@Id";
            

            conexion.Open();
            int filas = comando.ExecuteNonQuery();
            conexion.Close();


            return filas;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return -1;
        }
    }

    public string BorrarNomina(int IdFechaNomina)
    {
        OleDbCommand comando = new OleDbCommand();
        comando.Parameters.AddWithValue("@Fecha", IdFechaNomina);
        comando.Connection = conexion;
        comando.CommandText = "DELETE FROM NominaPorFecha WHERE Id = @Fecha";

        conexion.Open();
        int i = comando.ExecuteNonQuery();
        conexion.Close();

        if (i < 0)
        {
            return "Nomina no borrada";
        }

        return "Borrada";
    }

    public DataTable ContenidoNominaPorFecha(int Id) //Contenido Nomina Por Fecha
    {
        OleDbCommand comando = new OleDbCommand();
        comando.Parameters.AddWithValue("@Id", Id);
        comando.Connection = conexion;
        DataTable Nominas = new DataTable();

        comando.CommandText = "Select Id as [RowID], IdFechaNomina, IdEmpleado as Id, Nombre, Apellido, Cedula, Igualado, Salario, SalarioHora, HorasOrdinarias, HorasExtras, HorasDobles, DiasVacaciones, Comisiones, OtrasDeducciones FROM Nomina WHERE IdFechaNomina=@Id ORDER BY IdEmpleado";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);

        conexion.Open();
        adaptador.Fill(Nominas);
        conexion.Close();

        return Nominas;
    }

    public DataTable TodosLosPonches(DateTime Fecha1, DateTime Fecha2) //Mira a ver si me pagan que me acosté muy tarde jodiendo con eso.
    {
        OleDbCommand comando = new OleDbCommand();
        //comando.Parameters.AddWithValue("@Fecha1", "31/05/2016 08:37:55 a.m.");
        // comando.Parameters.AddWithValue("@Fecha2", "31/05/2016 01:02:33 p.m.");
        comando.Parameters.AddWithValue("@Fecha1", Fecha1);
        comando.Parameters.AddWithValue("@Fecha2", Fecha2);
        comando.Connection = conexionScanner;
        DataTable Horas = new DataTable();
        comando.CommandText = "SELECT USERID, CHECKTIME from CHECKINOUT WHERE CHECKTIME between @Fecha1 and @Fecha2 ORDER BY USERID ASC, CHECKTIME ASC"; //.USERID AS ID, CHECKINOUT.CHECKTIME AS PONCHE FROM CHECKINOUT WHERE(((CHECKINOUT.CHECKTIME)Between #" + Fecha1 + " 00:00:00# And #" + Fecha2 + " 23:59:59#)) ORDER BY CHECKINOUT.USERID ASC, CHECKINOUT.CHECKTIME ASC";
        //comando.CommandText = "SELECT CHECKINOUT.USERID AS ID, CHECKINOUT.CHECKTIME AS PONCHE FROM CHECKINOUT WHERE(((CHECKINOUT.CHECKTIME)Between #" + Fecha1 + " 00:00:00# And #" + Fecha2 + " 23:59:59#)) ORDER BY CHECKINOUT.USERID ASC, CHECKINOUT.CHECKTIME ASC";        
        OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);

        conexion.Open();
        adaptador.Fill(Horas);
        conexion.Close();

        return Horas;
    }

    public DataTable LiquidacionPorEmpleado(int Id) //Tony este metodo es para la liquidacion.
    {
        OleDbCommand comando = new OleDbCommand();
        comando.Parameters.AddWithValue("@Id", Id);
        comando.Connection = conexion;
        DataTable dtLiquidacion = new DataTable();

        comando.CommandText = "SELECT IdEmpleado As Código, FechaPrimeraNomina As PrimeraFecha, FechaDeNomina As SegundaFecha, Salario, SalarioSemanal, Comisiones FROM Nomina WHERE IdEmpleado=@Id ORDER BY Nombre, FechaDeNomina DESC";
        OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);

        conexion.Open();
        adaptador.Fill(dtLiquidacion);
        conexion.Close();

        return dtLiquidacion;

    }

}

