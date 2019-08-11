Module Module1
    Private clientes As New LinkedList(Of String)
    Private nombre, viejito, embarazada As String
    Sub Main()
        Call carga()
    End Sub
    Sub carga()
        Dim turno As String
        Dim prioridad As Byte
        viejito = ""
        embarazada = ""
        Do
            Console.Write("Ingrese nombre del cliente:")
            nombre = Console.ReadLine()
            If nombre <> "" Then
                Console.WriteLine("1. cliente normal")
                Console.WriteLine("2. cliente embarazada")
                Console.WriteLine("3. cliente de edad avanzada")
                prioridad = Console.ReadLine()
                Select Case prioridad
                    Case 1
                        normalitos(nombre)
                    Case 2
                        preñadas(nombre)
                        embarazada = nombre
                    Case 3
                        viejos(nombre)
                        viejito = nombre
                End Select

            End If
        Loop Until (nombre = "")
        Do
            Console.Write("Presione enter para continuar:")
            turno = Console.ReadLine()
            siguiente()
        Loop Until (clientes.Count = 0)
    End Sub
    Sub normalitos(ByVal nombres As String)
        clientes.AddLast(nombres)
    End Sub
    Sub preñadas(ByVal nombres As String)
        If clientes.Contains(viejito) Then
            If clientes.Contains(embarazada) Then
                clientes.AddAfter(clientes.FindLast(embarazada), nombres)
            Else
                clientes.AddAfter(clientes.FindLast(viejito), nombres)
            End If
        Else
            If clientes.Contains(embarazada) Then
                clientes.AddAfter(clientes.FindLast(embarazada), nombres)
            Else
                clientes.AddFirst(nombres)
            End If
        End If

    End Sub
    Sub viejos(ByVal nombres As String)
        If clientes.Contains(viejito) Then
            clientes.AddAfter(clientes.FindLast(viejito), nombres)
        Else
            clientes.AddFirst(nombres)
        End If
    End Sub
    Sub siguiente()
        Console.WriteLine("El turno es de {0}", clientes(0))
        clientes.RemoveFirst()
        If clientes.Count > 0 Then
            Console.WriteLine("En {0} espera", clientes.Count)
        Else
            Console.WriteLine("Sin clientes")
        End If

    End Sub

End Module
