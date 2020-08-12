#Region "版 本 注 释 "
' ----------------------------------------------------------------
' 项目名称 ：Schoolmate.Database.Conn
' 项目描述 ：数据库链接
' 类 名 称 ：exe
' 类 描 述 ：数据库加解密类
' 命名空间 ：Schoolmate.Database.Conn
' CLR 版本 ：4.0
' 作    者 ：fesugar
' 邮    箱 ：fesugar@fesugar.com
' 创建时间 ：12:42 2020/3/16
' 更新时间 ：12:42 2020/3/16
' 版 本 号 ：v1.0.0.0
' 参考文献 ：
' *****************************************************************
' * Copyright @ fesugar 2020.com. All rights reserved.
' *****************************************************************
' ----------------------------------------------------------------*
#End Region

Imports System.Xml
Imports System.IO
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Reflection

<Assembly: AssemblyVersionAttribute("4.3.210.110")> 
<Assembly: AssemblyTitle("Conn for Schoolmate.info")> 
<Assembly: AssemblyProduct("Schoolmate.Database.Conn .NET")> 
<Assembly: AssemblyDescription("Schoolmate.Database.Conn .NET Framework 4")> 
<Assembly: AssemblyCopyright("Copyright © 2014-2015 fesugar.com All rights reserved.")> 
<Assembly: Runtime.CompilerServices.CompilationRelaxationsAttribute(8)> 


''' <summary>
''' XML配置文件数据加解密控制台程序。
''' </summary>
''' <remarks></remarks>
Public Class exe

    Public Shared Sub Main(ByVal args As String())

        If (args.Length <> 2) Then

            exe.Usage(args)
            Return
        Else
            Dim xmlfile = args(0)
            Dim model = args(1)

            ' Create an XmlDocument object.
            Dim xmlDoc As New XmlDocument()

            ' Load an XML file into the XmlDocument object.
            Try
                xmlDoc.PreserveWhitespace = True
                xmlDoc.Load(xmlfile)
            Catch e As Exception
                Console.WriteLine(e.Message)
            End Try
            ' Create a new CspParameters object to specify
            ' a key container.
            Dim cspParams As New CspParameters()
            cspParams.KeyContainerName = "XML_ENC_RSA_KEY"
            ' Create a new RSA key and save it in the container.  This key will encrypt
            ' a symmetric key, which will then be encryped in the XML document.
            Dim rsaKey As New RSACryptoServiceProvider(cspParams)
            Try
                ' Encrypt the "creditcard" element.
                If model = "Encrypt" Then
                    Conn.Encrypt(xmlDoc, "Conn", "EncryptedElement1", rsaKey, "rsaKey")
                    ''Save the XML document.
                    ' /// xmlDoc.Save("Schoolmate.conn.xml")

                    ' Display the encrypted XML to the console.
                    Console.WriteLine("Encrypted XML:")
                    Console.WriteLine()
                    Console.WriteLine(xmlDoc.OuterXml)
                ElseIf model = "Decrypt" Then
                    Conn.Decrypt(xmlDoc, rsaKey, "rsaKey")
                    ' /// xmlDoc.Save("test1.xml")

                    ' Display the encrypted XML to the console.
                    Console.WriteLine()
                    Console.WriteLine("Decrypted XML:")
                    Console.WriteLine()
                    Console.WriteLine(xmlDoc.OuterXml)
                Else
                    Console.WriteLine("usage is missing.")
                    Return
                End If
               
            Catch e As Exception
                Console.WriteLine(e.Message)
            Finally
                ' Clear the RSA key.
                rsaKey.Clear()
            End Try


            '  Console.ReadLine()

        End If

        Return
    End Sub

    Private Shared Function Usage(ByVal args As String()) As Integer
        Console.WriteLine("Schoolmate.info connect database password. " + vbLf + " Usage: " + vbLf + " Schoolmate.Database.Conn < xmlfile > < model [ Encrypt or Decrypt ] >")
        Console.WriteLine("   xmlfile               Need to Encrypt or Decrypt xml file.")
        Console.WriteLine("   Encrypt               Encrypt xml file.")
        Console.WriteLine("   Decrypt               Decrypt xml file.")
        'Console.WriteLine(System.Environment.NewLine & "<ENTER> to continue...")
        'Console.ReadLine()
        Return 1
    End Function


End Class

''' <summary>
''' 解密xml加密数据。
''' </summary>
''' <remarks></remarks>
Public Class Conn

    ''' <summary>
    ''' 取得数据库连接密码。
    ''' </summary>
    ''' <param name="pwd">获取解密的数据库密码字段。</param>
    ''' <returns><c>True</c>解密成功。<c>False</c>解密失败。</returns>
    ''' <remarks></remarks>
    Public Function dbconn(ByRef pwd As String) As Boolean

        ' Create an XmlDocument object.
        Dim xmlDoc As New XmlDocument()

        ' Load an XML file into the XmlDocument object.
        Try
            xmlDoc.PreserveWhitespace = True
            xmlDoc.Load("Schoolmate.conn.xml")
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
        ' Create a new CspParameters object to specify
        ' a key container.
        Dim cspParams As New CspParameters()
        cspParams.KeyContainerName = "XML_ENC_RSA_KEY"
        ' Create a new RSA key and save it in the container.  This key will encrypt
        ' a symmetric key, which will then be encryped in the XML document.
        Dim rsaKey As New RSACryptoServiceProvider(cspParams)
        Try
            ' Encrypt the "creditcard" element.

            'Encrypt(xmlDoc, "Conn", "EncryptedElement1", rsaKey, "rsaKey")
            ''Save the XML document.
            ' /// xmlDoc.Save("Schoolmate.conn.xml")

            ' Display the encrypted XML to the console.
            'Console.WriteLine("Encrypted XML:")
            'Console.WriteLine()
            'Console.WriteLine(xmlDoc.OuterXml)


            Decrypt(xmlDoc, rsaKey, "rsaKey")
            ' /// xmlDoc.Save("test1.xml")

            ' Display the encrypted XML to the console.
            Console.WriteLine()
            Console.WriteLine("Decrypted XML:")
            Console.WriteLine()
            Console.WriteLine(xmlDoc.OuterXml)

            Dim xmlString As String = xmlDoc.OuterXml

            ' Create an XmlReader
            Using reader As XmlReader = XmlReader.Create(New StringReader(xmlString))

                reader.ReadToFollowing("PWD")
                reader.MoveToFirstAttribute()
                pwd = reader.Value
                Return True '成功解密
            End Using


        Catch e As Exception
            Console.WriteLine(e.Message)
        Finally
            ' Clear the RSA key.
            rsaKey.Clear()
        End Try

        Return False '出现错误
        'Console.ReadLine()

    End Function

    ' 用非对称密钥对 XML 元素进行加密 
    Public Shared Sub Encrypt(ByVal Doc As XmlDocument, ByVal EncryptionElement As String, ByVal EncryptionElementID As String, ByVal Alg As RSA, ByVal KeyName As String)
        ' Check the arguments.
        If Doc Is Nothing Then
            Throw New ArgumentNullException("Doc")
        End If
        If EncryptionElement Is Nothing Then
            Throw New ArgumentNullException("EncryptionElement")
        End If
        If EncryptionElementID Is Nothing Then
            Throw New ArgumentNullException("EncryptionElementID")
        End If
        If Alg Is Nothing Then
            Throw New ArgumentNullException("Alg")
        End If
        If KeyName Is Nothing Then
            Throw New ArgumentNullException("KeyName")
        End If
        '//////////////////////////////////////////////
        ' Find the specified element in the XmlDocument
        ' object and create a new XmlElemnt object.
        '//////////////////////////////////////////////
        Dim elementToEncrypt As XmlElement = Doc.GetElementsByTagName(EncryptionElement)(0) '

        ' Throw an XmlException if the element was not found.
        If elementToEncrypt Is Nothing Then
            Throw New XmlException("The specified element was not found")
        End If
        Dim sessionKey As RijndaelManaged = Nothing

        Try
            '////////////////////////////////////////////////
            ' Create a new instance of the EncryptedXml class
            ' and use it to encrypt the XmlElement with the
            ' a new random symmetric key.
            '////////////////////////////////////////////////
            ' Create a 256 bit Rijndael key.
            sessionKey = New RijndaelManaged()
            sessionKey.KeySize = 256
            Dim eXml As New EncryptedXml()

            Dim encryptedElement As Byte() = eXml.EncryptData(elementToEncrypt, sessionKey, False)
            '//////////////////////////////////////////////
            ' Construct an EncryptedData object and populate
            ' it with the desired encryption information.
            '//////////////////////////////////////////////
            Dim edElement As New EncryptedData()
            edElement.Type = EncryptedXml.XmlEncElementUrl
            edElement.Id = EncryptionElementID
            ' Create an EncryptionMethod element so that the
            ' receiver knows which algorithm to use for decryption.
            edElement.EncryptionMethod = New EncryptionMethod(EncryptedXml.XmlEncAES256Url)
            ' Encrypt the session key and add it to an EncryptedKey element.
            Dim ek As New EncryptedKey()

            Dim encryptedKey As Byte() = EncryptedXml.EncryptKey(sessionKey.Key, Alg, False)

            ek.CipherData = New CipherData(encryptedKey)

            ek.EncryptionMethod = New EncryptionMethod(EncryptedXml.XmlEncRSA15Url)
            ' Create a new DataReference element
            ' for the KeyInfo element.  This optional
            ' element specifies which EncryptedData
            ' uses this key.  An XML document can have
            ' multiple EncryptedData elements that use
            ' different keys.
            Dim dRef As New DataReference()

            ' Specify the EncryptedData URI.
            dRef.Uri = "#" + EncryptionElementID

            ' Add the DataReference to the EncryptedKey.
            ek.AddReference(dRef)
            ' Add the encrypted key to the
            ' EncryptedData object.
            edElement.KeyInfo.AddClause(New KeyInfoEncryptedKey(ek))
            ' Set the KeyInfo element to specify the
            ' name of the RSA key.
            ' Create a new KeyInfoName element.
            Dim kin As New KeyInfoName()

            ' Specify a name for the key.
            kin.Value = KeyName

            ' Add the KeyInfoName element to the
            ' EncryptedKey object.
            ek.KeyInfo.AddClause(kin)
            ' Add the encrypted element data to the
            ' EncryptedData object.
            edElement.CipherData.CipherValue = encryptedElement
            '//////////////////////////////////////////////////
            ' Replace the element from the original XmlDocument
            ' object with the EncryptedData element.
            '//////////////////////////////////////////////////
            EncryptedXml.ReplaceElement(elementToEncrypt, edElement, False)
        Catch e As Exception
            ' re-throw the exception.
            Throw e
        Finally
            If Not (sessionKey Is Nothing) Then
                sessionKey.Clear()
            End If
        End Try

    End Sub 'Encrypt

    ' 用非对称密钥对 XML 元素进行解密 
    Public Shared Sub Decrypt(ByVal Doc As XmlDocument, ByVal Alg As RSA, ByVal KeyName As String)
        ' Check the arguments.  
        If Doc Is Nothing Then
            Throw New ArgumentNullException("Doc")
        End If
        If Alg Is Nothing Then
            Throw New ArgumentNullException("Alg")
        End If
        If KeyName Is Nothing Then
            Throw New ArgumentNullException("KeyName")
        End If
        ' Create a new EncryptedXml object.
        Dim exml As New EncryptedXml(Doc)

        ' Add a key-name mapping.
        ' This method can only decrypt documents
        ' that present the specified key name.
        exml.AddKeyNameMapping(KeyName, Alg)

        ' Decrypt the element.
        exml.DecryptDocument()

    End Sub 'Decrypt 


End Class
