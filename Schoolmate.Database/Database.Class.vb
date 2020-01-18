Imports System.Data.OleDb
Imports System.Reflection

<Assembly: AssemblyVersionAttribute("4.3.2.220")> 
<Assembly: AssemblyTitle("Database for Schoolmate.info")> 
<Assembly: AssemblyProduct("Schoolmate.Database .NET")> 
<Assembly: AssemblyDescription("Schoolmate.Database .NET Framework 4")> 
<Assembly: AssemblyCopyright("Copyright © 2014-2015 T-Sugar All rights reserved.")> 
<Assembly: Runtime.CompilerServices.CompilationRelaxationsAttribute(8)> 



''' <summary>
''' mdb 数据库操作方法。
''' </summary>
''' <remarks></remarks>
Public Class Database

    ''' <summary>
    ''' 操作 mdb 数据库进行查询/添加/修改/删除
    ''' </summary>
    ''' <param name="DataSource">指定连接到的数据源的名称。</param>
    ''' <param name="Provider">指定连接字符串关联的数据提供程序的名称。</param>
    ''' <param name="Password">指定连接到的数据源的密码。</param>
    ''' <param name="OleDbCmd">指定 SQL 命令。</param>
    ''' <param name="Options">指定执行的状态 1:检测是否注册 2:验证登陆 
    ''' 3:查询数据 4:添加/修改/删除 数据 5:获取地址ID 。</param>
    ''' <param name="Getstring">指定返回的数据。</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Access_db(
                        ByVal DataSource As String,
                        ByVal Provider As String,
                        ByVal Password As String,
                        ByVal OleDbCmd As String,
                        ByVal Options As Integer,
                        ByRef Getstring As String)

        ' 声明为创建和管理由 OleDbConnection 类使用的连接字符串的内容提供了一种简单方法。
        Dim builder As New OleDbConnectionStringBuilder()
        ' 获取或设置要连接到的数据源的名称。
        builder.DataSource = DataSource
        ' 获取或设置一个字符串，该字符串包含与内部连接字符串关联的数据提供程序的名称。
        builder.Provider = Provider
        ' 将带有指定键和值的项添加到 DbConnectionStringBuilder 中。
        builder.Add("Jet OLEDB:Database Password", Password)
        ' builder("User Id") = "Admin;NewValue=Bad"
        ' 控制台输出显示连接字符串
        Console.WriteLine(builder.ConnectionString)

        ' If the connection string is null, use a default.
        If builder.ConnectionString = "" Then
            builder.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\test.mdb;User Id=username;Password=pass;"
        End If

        ' This sample assumes that you have a database named
        ' C:\Sample.mdb available.
        Using connection As New OleDbConnection(builder.ConnectionString)

            ' The insertSQL string contains a SQL statement that
            ' inserts a new row in the source table.
            Dim command As New OleDbCommand(OleDbCmd)
            ' 获取或设置在终止对执行命令的尝试并生成错误之前的等待时间。
            command.CommandTimeout = 20

            ' Set the Connection to the new OleDbConnection.
            command.Connection = connection

            ' Open the connection and execute the insert command.
            Try
                connection.Open()
                ' Do something with the database here.

                Console.WriteLine("query:" & command.ExecuteNonQuery())

                Select Case Options

                    Case 1 ' login 检测是否注册
                        Dim reader As OleDbDataReader = command.ExecuteReader()

                        ' Call Read before accessing data.
                        While reader.Read()
                            ' ReadSingleRow(CType(reader, IDataRecord))
                            Getstring = reader("Info_admin".ToString)
                            'Console.WriteLine(reader("字段名"))
                            'Console.WriteLine(reader(0).ToString)
                        End While

                        ' Call Close when done reading.
                        reader.Close()

                    Case 2 ' 验证登录
                        Dim reader As OleDbDataReader = command.ExecuteReader()

                        ' Call Read before accessing data.
                        While reader.Read()
                            ' ReadSingleRow(CType(reader, IDataRecord))
                            Getstring = reader("Info_username".ToString) & reader("Info_password".ToString)
                            Console.WriteLine(Getstring)
                            'Console.WriteLine(reader("字段名"))
                            'Console.WriteLine(reader(0).ToString)
                        End While

                        ' Call Close when done reading.
                        reader.Close()

                    Case 3 ' 查询数据
                        Dim reader As OleDbDataReader = command.ExecuteReader()

                        ' Call Read before accessing data.
                        While reader.Read()

                            Getstring = reader("compellation").ToString
                        End While

                        ' Call Close when done reading.
                        reader.Close()
                    Case 4 ' 添加数据/更新数据/删除数据
                        Return True.ToString
                    Case 5 ' 获取地址ID
                        Dim reader As OleDbDataReader = command.ExecuteReader()

                        ' Call Read before accessing data.
                        While reader.Read()
                            ' ReadSingleRow(CType(reader, IDataRecord))
                            Getstring = reader("ID").ToString
                            'Console.WriteLine(reader("字段名"))
                            'Console.WriteLine(reader(0).ToString)
                        End While

                        ' Call Close when done reading.
                        reader.Close()

                    Case Else

                End Select
            Catch ex As System.InvalidOperationException
                Return "InvalidOperationException" ' 未注册 oledb4.0
            Catch ex As System.Data.OleDb.OleDbException
                Return "OleDbException" ' 数据库连接错误
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

        End Using

        Console.WriteLine("The finish.")
        Console.ReadLine()

    End Function

End Class
