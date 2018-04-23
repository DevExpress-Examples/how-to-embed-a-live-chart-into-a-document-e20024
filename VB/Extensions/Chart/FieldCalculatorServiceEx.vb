﻿Imports DevExpress.XtraRichEdit.Model
Imports DevExpress.XtraRichEdit.Fields
Imports System

Namespace BizPad

    Public Class FieldCalculatorServiceEx
        Inherits FieldCalculatorService
        Implements IFieldCalculatorService

        Protected Overrides Function CreateInitializedCalculatedField(ByVal pieceTable As PieceTable, ByVal firstToken As Token, ByVal scanner As FieldScanner) As CalculatedFieldBase

            Dim chartToken As Token = firstToken
            If chartToken IsNot Nothing Then
                If String.Equals(chartToken.Value, "CHART", StringComparison.OrdinalIgnoreCase) Then
                    Return CreateInitializedChartField(pieceTable,scanner)
                End If
            End If

            Return MyBase.CreateInitializedCalculatedField(pieceTable, firstToken, scanner)
        End Function

        Private Shared Function CreateInitializedChartField(ByVal pieceTable As PieceTable, ByVal scanner As FieldScanner) As CalculatedFieldBase
            Dim field As CalculatedFieldBase = New ChartField()
            If field Is Nothing Then
                Return Nothing
            End If

            Dim instructions As InstructionCollection = ParseInstructions(scanner, field)
            field.Initialize(pieceTable, instructions)
            Return field
        End Function
    End Class
End Namespace
