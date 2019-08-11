Module Module1
    Private palabra As New Stack
    Private aux As String
    Sub Main()
        Call reversa()
    End Sub

    Sub reversa()
        Console.Write("Ingrese un palabra o frase: ")
        aux = Console.ReadLine()
        For x = 1 To Len(aux)
            palabra.Push(Mid(aux, x, 1))
        Next
        Console.Write("la palabra volteada es: ")
        For x = 0 To (palabra.Count - 1)
            Console.Write(palabra.Pop)
        Next
        Console.WriteLine("")
    End Sub


End Module
