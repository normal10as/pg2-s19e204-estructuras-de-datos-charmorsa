Imports System

Module Program
    Sub Main(args As String())
        Dim sumatoria, vector(4) As Integer
        Call carga(sumatoria, vector)
        Console.WriteLine("La sumatoria de todos los elementos: " & sumatoria)
        Console.WriteLine("La media: " & media(sumatoria, vector))
        Call mostrar(sumatoria, vector)
    End Sub

    Sub carga(ByRef sum As Integer, ByRef vec() As Integer)
        For i = 0 To vec.Length - 1
            Console.WriteLine("Ingrese un numero")
            vec(i) = Console.ReadLine()
            sum += vec(i)
        Next
    End Sub

    Function media(ByRef sum As Integer, ByRef vec() As Integer) As Single
        Return sum / vec.Length
    End Function

    Sub mostrar(ByRef sum As Integer, ByRef vec() As Integer)
        For i = 0 To vec.Length - 1
            Console.WriteLine("indice: {0}, valor: {1}, su desviacion: {2} ", i, vec(i), vec(i) - media(sum, vec))
        Next
    End Sub
End Module
