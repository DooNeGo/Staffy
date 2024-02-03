﻿using CourseWork2.Model;
using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public class RetiredWorkersRepository : RepositoryBase<RetiredWorkerModel>
{
    public RetiredWorkersRepository()
    {
        GetByIdCommand.CommandText = "SELECT a.id, w.surname, w.name, w.patronymic, "   +
                                     "DATE_FORMAT(a.retire_date, '%d/%m/%Y'), pension " +
                                     "FROM retired_workers as a, workers as w "         +
                                     "WHERE a.id = @id AND w.id = a.worker_id";
        GetByIdCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));

        GetAllCommand.CommandText = "SELECT a.id, w.surname, w.name, w.patronymic, "   +
                                    "DATE_FORMAT(a.retire_date, '%d/%m/%Y'), pension " +
                                    "FROM retired_workers as a, workers as w "         +
                                    "WHERE w.id = a.worker_id";

        GetAllByStringCommand.CommandText = "SELECT a.id, w.surname, w.name, w.patronymic, " +
                                            "DATE_FORMAT(a.retire_date, '%d/%m/%Y'), pension " +
                                            "FROM retired_workers as a, workers as w " +
                                            "WHERE w.id = a.worker_id " +
                                            "AND (@string = a.id OR @string = w.id " +
                                            "OR LOCATE(@string, w.surname) > 0 OR LOCATE(w.surname, @string) > 0 " +
                                            "OR LOCATE(@string, w.name) > 0 OR LOCATE(w.name, @string) > 0 " +
                                            "OR LOCATE(@string, w.patronymic) > 0 OR LOCATE(w.patronymic, @string) > 0 " +
                                            "OR @string = DATE_FORMAT(a.retire_date, '%d/%m/%Y'))";
        GetAllByStringCommand.Parameters.Add(new MySqlParameter("@string", MySqlDbType.VarChar));

        DeleteCommand.CommandText = "DELETE FROM retired_workers WHERE id = @id";
        DeleteCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));
    }
}