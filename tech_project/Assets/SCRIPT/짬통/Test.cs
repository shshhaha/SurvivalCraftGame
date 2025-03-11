using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class Test
{

    private SqliteConnection m_DatabaseConnection; //SQLite 데이터베이스에 대한 연결을 나타내는 변수입니다.
    private SqliteCommand m_DatabaseCommand; //SQLite 데이터베이스에 대한 명령을 나타내는 변수입니다.
    private SqliteDataReader m_Reader; //SQLite 데이터베이스에서 데이터를 읽는 데 사용되는 변수입니다.

    public Test (string connectionString)
    {
        OpenDatabase(connectionString);
    }

    public void OpenDatabase(string connectionString) // Test 클래스의 생성자
    {
        m_DatabaseConnection = new SqliteConnection(connectionString);
        m_DatabaseConnection.Open();
        Debug.Log("Connected to database");
    }

    public void CloseSqlConnection() //DB연결 종료
    {
        if (m_DatabaseCommand != null) //객체가 존재하는 경우 Dispose() 메서드를 호출하여 리소스를 해제합니다.
        {
            m_DatabaseCommand.Dispose();
        }

        m_DatabaseCommand = null; //m_DatabaseCommand 변수에 null을 할당하여 참조를 제거합니다. Garbage Collector가 해당 객체를 수집하고 메모리에서 제거

        if (m_Reader != null) //m_Reader 객체가 존재하면 그 리소스를 해제합니다.
        {
            m_Reader.Dispose();
        }

        m_Reader = null;

        if (m_DatabaseConnection != null)  //데이터베이스 연결(m_DatabaseConnection)이 존재한다면, 그 연결을 닫습니다(Close()).
        {
            m_DatabaseConnection.Close();
        }

        m_DatabaseConnection = null;
        Debug.Log("Disconnected from database.");
    }

    public SqliteDataReader ExecuteQuery(string sqlQuery) //SQL 쿼리를 실행하고 그 결과를 반환하는 역할, 데이터베이스에서 조회, 삽입, 업데이트, 삭제 등의 작업을 수행하는 데 사용
    {
        m_DatabaseCommand = m_DatabaseConnection.CreateCommand(); //새로운 커맨드 객체(m_DatabaseCommand)를 생성
        m_DatabaseCommand.CommandText = sqlQuery; //CommandText 속성에 입력받은 SQL 쿼리를 설정. 이 커맨드가 실행될 때 해당 SQL 쿼리가 데이터베이스에서 수행

        m_Reader = m_DatabaseCommand.ExecuteReader(); //커맨드 객체의 ExecuteReader() 메서드를 호출하여 SQL 쿼리를 데이터베이스에서 실행하고, 그 결과로 반환된 레코드 집합을 읽을 수 있는 SqliteDataReader 객체(m_Reader)를 생성

        return m_Reader; //함수를 호출한 코드에서 데이터베이스 조회 결과에 접근할 수 있게 됩
    }

    public SqliteDataReader ReadFullTable(string tableName) //특정 테이블의 모든 레코드를 읽어오는 역할
    {
        string query = "SELECT * FROM " + tableName; //입력받은 테이블 이름(tableName)을 사용하여 SQL 쿼리를 생성
        return ExecuteQuery(query);
    }

    public SqliteDataReader InsertInto(string tableName, string[] values)
    {
        string query = "INSERT INTO " + tableName + " VALUES (" + values[0];
        for (int i = 1; i < values.Length; ++i)
        {
            query += ", " + values[i];
        }
        query += ")";
        return ExecuteQuery(query);
    }

    public SqliteDataReader InsertIntoSpecific(string tableName, string[] cols, string[] values) //틀정 테이블에 새로운 레코드를 삽입
    {
        if (cols.Length != values.Length)
        {
            throw new SqliteException("columns.Length != values.Length");
        }
        string query = "INSERT INTO " + tableName + "(" + cols[0];
        for (int i = 1; i < cols.Length; ++i)
        {
            query += ", " + cols[i];
        }
        query += ") VALUES (" + values[0];
        for (int i = 1; i < values.Length; ++i)
        {
            query += ", " + values[i];
        }
        query += ")";
        return ExecuteQuery(query);
    }

    public SqliteDataReader UpdateInto(string tableName, string[] cols, string[] colsvalues, string selectkey, string selectvalue)
    {

        string query = "UPDATE " + tableName + " SET " + cols[0] + " = " + colsvalues[0];

        for (int i = 1; i < colsvalues.Length; ++i)
        {

            query += ", " + cols[i] + " =" + colsvalues[i];
        }

        query += " WHERE " + selectkey + " = " + selectvalue + " ";

        return ExecuteQuery(query);
    }

    public SqliteDataReader DeleteContents(string tableName)
    {
        string query = "DELETE FROM " + tableName;
        return ExecuteQuery(query);
    }

    public SqliteDataReader CreateTable(string name, string[] col, string[] colType)
    {
        if (col.Length != colType.Length)
        {
            throw new SqliteException("columns.Length != colType.Length");
        }
        string query = "CREATE TABLE " + name + " (" + col[0] + " " + colType[0];
        for (int i = 1; i < col.Length; ++i)
        {
            query += ", " + col[i] + " " + colType[i];
        }
        query += ")";
        return ExecuteQuery(query);
    }

    public SqliteDataReader SelectWhere(string tableName, string[] items, string[] col, string[] operation, string[] values)
    {
        if (col.Length != operation.Length || operation.Length != values.Length)
        {
            throw new SqliteException("col.Length != operation.Length != values.Length");
        }
        string query = "SELECT " + items[0];
        for (int i = 1; i < items.Length; ++i)
        {
            query += ", " + items[i];
        }
        query += " FROM " + tableName + " WHERE " + col[0] + operation[0] + "'" + values[0] + "' ";
        for (int i = 1; i < col.Length; ++i)
        {
            query += " AND " + col[i] + operation[i] + "'" + values[0] + "' ";
        }

        return ExecuteQuery(query);
    }
}
