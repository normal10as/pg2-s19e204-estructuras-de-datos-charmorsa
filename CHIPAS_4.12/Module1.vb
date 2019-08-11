Module Module1
    Private bebidas As New SortedList(Of Byte, String)
    Private precio As New SortedList(Of Byte, Single)
    Private opcion As Byte
    Sub Main()
        Call MENU()
    End Sub
    Sub MENU()
        Do
            Console.WriteLine("SISTEMA DE BEBIDAS")
            Console.WriteLine("1. Agregar")
            Console.WriteLine("2. Editar")
            Console.WriteLine("3. Eliminar")
            Console.WriteLine("4. Listar")
            Console.WriteLine("5. Salir")
            Console.Write("Elija una opcion: ")
            opcion = Console.ReadLine()
            Select Case opcion
                Case 1
                    agregar()
                Case 2
                    editar()
                Case 3
                    eliminar()
                Case 4
                    lista()
                Case 5
                    Console.WriteLine("[SALIR]")
            End Select
        Loop Until (opcion = 5)
    End Sub
    Sub agregar()
        Dim clave As Byte
        Dim nombre As String
        Dim costo As Single
        Do
            Console.Write("Ingrese el codigo(Numeros): ")
            clave = Console.ReadLine()
            If precio.ContainsKey(clave) Then
                Console.WriteLine("Error clave ya existe")
            Else
                Exit Do
            End If
        Loop While 1
        Do
            Console.Write("Ingrese Nombre: ")
            nombre = Console.ReadLine()
            If bebidas.ContainsValue(nombre) Then
                Console.WriteLine("Error nombre ya existe")
            Else
                Exit Do
            End If
        Loop While 1
        Console.Write("Ingrese Precio: ")
        costo = Console.ReadLine()
        bebidas.Add(clave, nombre)
        precio.Add(clave, costo)
    End Sub
    Sub editar()
        Dim aux, id As Byte
        Dim cierre As String
        Do
            Console.Write("Ingrese el codigo: ")
            id = Console.ReadLine()
            If precio.ContainsKey(id) Then
                Do
                    Console.Write("Que desea modificar: ")
                    Console.Write("1. nombre / ")
                    Console.WriteLine("                                 2. precio ")
                    aux = Console.ReadLine()
                    Select Case aux
                        Case 1
                            bebidas(id) = editar_nombre()
                        Case 2
                            precio(id) = editar_precio()
                        Case Else
                            Console.WriteLine("VALOR INVALIDO ")
                    End Select
                    Console.Write("Desea hacer otra modificacion? SI / NO ")
                    cierre = Console.ReadLine()
                Loop Until UCase(cierre) = "NO"
            Else
                Console.WriteLine("Error clave no existe")
            End If
        Loop Until (precio.ContainsKey(id))
    End Sub
    Function editar_nombre() As String
        Console.Write("NUEVO NOMBRE: ")
        Return Console.ReadLine()
    End Function
    Function editar_precio() As Single
        Console.Write("NUEVO PRECIO: ")
        Return Console.ReadLine()
    End Function
    Sub eliminar()
        Dim id As Byte
        Do
            Console.Write("Ingrese la Clave de la bebida: ")
            id = Console.ReadLine()
            If precio.ContainsKey(id) Then
                bebidas.Remove(id)
                precio.Remove(id)
                Exit Do
            Else
                Console.WriteLine("Error Clave no existe")
            End If
        Loop While 1
    End Sub
    Sub lista()
        For Each key In bebidas.Keys
            Console.WriteLine("{0}: {1}", bebidas(key), precio(key))
        Next
    End Sub

End Module
