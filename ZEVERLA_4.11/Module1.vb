Module Module1
    Private palabra As New Stack(Of String)
    Private aux As String
    Sub Main()
        Call carga()
        Call retroseso()
    End Sub

    Sub carga()
        Console.Write("Ingrese un palabra o frase: ")
        aux = Console.ReadLine()
        For x = 1 To Len(aux)
            palabra.Push(Mid(aux, x, 1))
        Next
    End Sub

    Sub retroseso()
        Console.Write("Orden invertido: ")
        For x = 0 To (palabra.Count - 1)
            Console.Write(palabra.Pop)
        Next
        Console.WriteLine()
    End Sub
End Module
