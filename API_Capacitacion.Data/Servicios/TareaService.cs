using API_Capacitacion.Data.Interfaces;
using API_Capacitacion.DTO.Tarea;
using API_Capacitacion.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Capacitacion.Data.Servicios
{
    public class TareaService : ITareaService
    {
        private PostgresqlConfiguration _connection;

        public TareaService(PostgresqlConfiguration connection ) => _connection = connection;

        private NpgsqlConnection CreateConnection() => new(_connection.Connection);

        #region create

        public async Task<TareaModel> Create(CreateTareaDTO createTareaDTO)
        {
            using NpgsqlConnection database = CreateConnection();
            string sqlQuery = "select * from fun_task_create (" +
                "p_tarea := @task," +
                "p_descripcion := @description," +
                "p_IdUsuario := @userId" +
                ");";

            try
            {
                await database.OpenAsync();

                var result = await database.QueryAsync<TareaModel, UserModel, TareaModel>(
                    sqlQuery,
                   param: new
                    {
                        task = createTareaDTO.tarea,
                        description = createTareaDTO.descripcion,
                        userId = createTareaDTO.IdUsuario
                    },
                    map: (task, user) =>
                    {
                        task.Usuario = user;

                        return task;
                    },
                    splitOn: "UsuarioId"
                    );

                await database.CloseAsync();

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }   
        }
        #endregion

    }
}
