Imports Microsoft.VisualBasic.Collection
Module Module1
    Private domipais As New Collection
    Sub Main()
        Call datos()
        Call menu()
    End Sub
    Sub datos()
        domipais.Add("Argentina", "arg")
        domipais.Add("Paraguay", "par")
        domipais.Add("Bolivia", "bol")
        domipais.Add("Chile", "chi")
        domipais.Add("Brasil", "bra")
        domipais.Add("Uruguay", "urg")
        domipais.Add("Ecuador", "ecu")
        domipais.Add("Peru", "per")
        domipais.Add("Colombia", "col")
        domipais.Add("Venezuela", "ven")
        domipais.Add("Panama", "pan")
        domipais.Add("Honduras", "hon")
    End Sub
    Sub menu()
        Dim elegir As Byte
        Console.WriteLine("------------------------------------")
        Console.WriteLine("QUE DESEA HACER?")
        Console.WriteLine("1-agregar")
        Console.WriteLine("2-buscar")
        Console.WriteLine("3-mostrar todos")
        Console.WriteLine("4-cantidad")
        Console.WriteLine("5-salir")
        Console.Write("seleccione una opcion: ")
        elegir = Console.ReadLine()
        Select Case elegir
            Case 1
                Call carga()
            Case 2
                Call busqueda()
            Case 3
                Call mostrar()
            Case 4
                Call cantidad()
            Case 5
                End 
        End Select
    End Sub
    Sub carga()
        Dim bucle, nombre, cod As String
        Do
            Console.Write("ingrese el nombre del pais: ")
            nombre = Console.ReadLine()
            Console.Write("ingrese el dominio de dicho pais: ")
            cod = Console.ReadLine()
            domipais.Add(nombre, cod)
            Console.Write("desea ingresar otro pais? NO para salir, SI para continuar: ")
            bucle = Console.ReadLine()
        Loop Until UCase(bucle) = "NO"
        Call menu()
    End Sub
    Sub acciones(ByVal cod As String)
        Dim acc As Byte
        Console.WriteLine("que desea hacer con el dato encontrado?")
        Console.WriteLine("1- editar")
        Console.WriteLine("2- eliminar")
        acc = Console.ReadLine()
        If acc = 1 Then
            Call editar(cod)
        ElseIf acc = 2 Then
            Call eliminar(cod)
        Else
            Console.Write("error de codigo ")
        End If
        Call menu()
    End Sub
    Sub editar(ByVal codigo As String)
        Dim nuevo_nombre, nuevo_codigo As String
        domipais.Remove(codigo)
        Console.Write("ingrese el nuevo nombre del pais: ")
        nuevo_nombre = Console.ReadLine()
        Console.Write("a continuacion el nuevo codigo: ")
        nuevo_codigo = Console.ReadLine()
        Console.WriteLine("edicion exitoso")
        domipais.Add(nuevo_nombre, nuevo_codigo)
    End Sub
    Sub eliminar(ByVal codigo As String)
        Console.WriteLine("borrado exitoso")
        domipais.Remove(codigo)
    End Sub
    Sub busqueda()
        Dim dominio As String
        Do
            Console.Write("INGRESE UN CODIGO DE DOMINIO. EJ: urg (Uruguay)...")
            dominio = Console.ReadLine()
            For Each cod In domipais
                If domipais.Contains(dominio) Then
                    Console.WriteLine("El Pais es '{0}' ", domipais(dominio))
                    Call acciones(dominio)
                    Exit For
                ElseIf dominio = "" Then
                    Console.WriteLine("fin")
                    Exit Do
                Else
                    Console.WriteLine("No existe ese dominio.")
                    Exit For
                End If
            Next
        Loop While dominio <> ""
        Call menu()
    End Sub
    Sub mostrar()
        For Each i In domipais
            Console.Write("---")
            Console.WriteLine(i)
        Next
        Call menu()
    End Sub
    Sub cantidad()
        Console.WriteLine("La cantidad de registros es de '{0}' paises", domipais.Count)
        Call menu()
    End Sub
End Module
