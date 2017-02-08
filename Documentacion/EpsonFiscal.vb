' **************************************************************************
' Propiedad intelectual EPSON ARGENTINA S.A.
' Programador: Gomez Guillermo
' Este software se entrega con fines didácticos y sin garantia alguna.
' EPSON NO ASUME responsabilidad legal alguna. El programador usa esta información
' bajo su propio riesgo y responsabilidad.
' **************************************************************************
Dim Funciones() As String
Dim AyudaFunciones() As String
Dim Parametros() As String


Private Sub Command1_Click(Index As Integer)
' **************************************************************************
' Propiedad intelectual EPSON ARGENTINA S.A.
' Programador: Gomez Guillermo
' Este software se entrega con fines didácticos y sin garantia alguna.
' EPSON NO ASUME responsabilidad legal alguna. El programador usa esta información
' bajo su propio riesgo y responsabilidad.
' **************************************************************************
Dim respuesta As Boolean

Screen.MousePointer = 11

    Select Case Index
    
        Case 0
            'Tique
            respuesta = Me.IF1.OpenTicket("G")
            If respuesta Then respuesta = Me.IF1.SendTicketItem("ARTICULO 1", "1000", "10", "2100", "M", "0", "0")
            If respuesta Then respuesta = Me.IF1.SendTicketItem("ARTICULO 2", "1000", "20", "2100", "M", "0", "0")
            If respuesta Then respuesta = Me.IF1.SendTicketItem("ARTICULO 3", "1000", "30", "2100", "M", "0", "0")
            If respuesta Then respuesta = Me.IF1.GetTicketSubtotal("P", "LINDO SUB")
            If respuesta Then respuesta = Me.IF1.SendTicketPayment("PAGO1", "200", "T")
            If respuesta Then respuesta = Me.IF1.CloseTicket
            
        
        Case 1
            'Tique Factura
            respuesta = True
            respuesta = Me.IF1.OpenInvoice("T", "C", "A", "1", "P", "12", "I", "F", "PEPE", "LE BOU", "CUIT", "30614104712", "N", "LA", "PAMPA", "98", "REM 1", "REM 2", "G")
            If respuesta Then respuesta = Me.IF1.SendInvoiceItem("ARTICULO 1", "1000", "10", "2100", "M", "0", "0", "", "", "", "1050", "0")
            If respuesta Then respuesta = Me.IF1.SendInvoiceItem("ARTICULO 2", "1000", "20", "2100", "M", "0", "0", "", "", "", "1050", "0")
            If respuesta Then respuesta = Me.IF1.SendInvoiceItem("ARTICULO 3", "1000", "30", "2100", "M", "0", "0", "", "", "", "1050", "0")
            If respuesta Then respuesta = Me.IF1.SendInvoiceItem("ARTICULO 4", "1000", "40", "2100", "M", "0", "0", "", "", "", "1050", "0")
            If respuesta Then respuesta = Me.IF1.SendInvoiceItem("ARTICULO 5", "1000", "50", "2100", "M", "0", "0", "", "", "", "1050", "0")
            If respuesta Then respuesta = Me.IF1.GetInvoiceSubtotal("P")
            If respuesta Then respuesta = Me.IF1.SendInvoicePayment("PAGO1", "1", "T")
            If respuesta Then respuesta = Me.IF1.CloseInvoice("T", "A", "")
        
        Case 2
            'dnf
            respuesta = Me.IF1.OpenNoFiscal
            If respuesta Then respuesta = Me.IF1.SendNoFiscalText("á12345678à")
            If respuesta Then respuesta = Me.IF1.CloseNoFiscal
            
        Case 3
            'DNFH TC Y OS
            respuesta = Me.IF1.DNFHCreditCard("VISA", "12", "PEPE", "991231", "23", "46", "57", "89", "CONTA", "100", "2", "PESOS", "2", "4", "5", "7", "8", "44", "P", "P", "P")
            If respuesta Then respuesta = Me.IF1.DNFHDrugstore("MEDICUS", "CO 1", "CO 2", "CO 3", "123", "PEP", "991030", "ADRESS", "ADDRESS 2", "NADA", "12", "EXTRA 1", "EXTRA 2", "P", "P", "P", "P", "P")
            
        Case 4
            'Hora y Fecha
            respuesta = Me.IF1.SetGetDateTime("S", Format(Date, "YYMMDD"), Format(Time, "HHMMSS"))
            If respuesta Then respuesta = Me.IF1.SetGetDateTime("G")
            If respuesta Then MsgBox "La fecha y la hora actuales de la impresora son: " & Me.IF1.AnswerField_3
            
        Case 5
            'cajon
            respuesta = Me.IF1.OpenCashDrawer("1")
            If respuesta Then respuesta = Me.IF1.OpenCashDrawer("2")
            
        Case 6
            'header /trailer
            respuesta = Me.IF1.SetGetHeaderTrailer("S", "1", "PRUEBA HEADER")
            If respuesta Then respuesta = Me.IF1.SetGetHeaderTrailer("G", "1")
            If respuesta Then MsgBox "El header obtenido es : " & Me.IF1.AnswerField_4
            
        Case 7
            respuesta = Me.IF1.Status
        
        Case 8
            'dnf por Slip
            respuesta = Me.IF1.SelectSlip
            If respuesta Then respuesta = Me.IF1.SetPaperSize(50, 88)
            If respuesta Then MsgBox "Inserte una hoja en la entrada de Slip", vbInformation, "ATENCION"
            If respuesta Then respuesta = Me.IF1.PrepareSlip
            If respuesta Then MsgBox "Se imprimirá un documento no fiscal por slip", vbInformation, "ATENCION"
            If respuesta Then respuesta = Me.IF1.OpenSlipNoFiscal
            If respuesta Then respuesta = Me.IF1.SendNoFiscalText("       E J E M P L O")
            If respuesta Then respuesta = Me.IF1.SendNoFiscalText("S L I P   N O   F I S C A L")
            If respuesta Then respuesta = Me.IF1.SendNoFiscalText(" P O R   O C X F I S C A L")
            If respuesta Then respuesta = Me.IF1.CloseNoFiscal
        
        Case 9
            'Factura
            respuesta = Me.IF1.OpenInvoice("F", "C", "A", "1", "P", "12", "I", "I", "PEPE", "LE BOU", "CUIT", "30614104712", "N", "LA", "PAMPA", "98", "REM 1", "REM 2", "C")
            If respuesta Then respuesta = Me.IF1.SendInvoiceItem("ARTICULO 1", "1000", "100", "2100", "M", "0", "0", "EXTRA", "EXTRA", "EXTRA", "1050", "0")
            'If respuesta Then respuesta = Me.if1.GetInvoiceSubtotal("P", "LINDO SUB")
            If respuesta Then respuesta = Me.IF1.SendInvoicePayment("PAGO1", "200", "T")
            If respuesta Then respuesta = Me.IF1.CloseInvoice("F", "A", "HOLA")
        Case 10
'            respuesta = Me.IF1.OpenInvoice("F", "C", "A", "1", "P", "12", "I", "I", "PEPE", "LE BOU", "CUIT", "30614104712", "N", "LA", "PAMPA", "98", "REM 1", "REM 2", "C")
'            If respuesta Then respuesta = Me.IF1.SendInvoiceItem("ARTICULO 1", "1000", "100", "2100", "M", "0", "0", "EXTRA", "EXTRA", "EXTRA", "1050", "0")
'            'If respuesta Then respuesta = Me.if1.GetInvoiceSubtotal("P", "LINDO SUB")
'            If respuesta Then respuesta = Me.IF1.SendInvoicePayment("PAGO1", "200", "T")
'            If respuesta Then respuesta = Me.IF1.CloseInvoice("F", "A", "HOLA")
        
        Case 11 'setea diseño de factura
            respuesta = SeteoFactura(Me.IF1)
        Case 12 'Factura con transporte
            respuesta = Me.IF1.OpenInvoice("F", "C", "A", "1", "P", "12", "I", "I", "PEPE", "LE BOU", "CUIT", "30614104712", "N", "LA", "PAMPA", "98", "REM 1", "REM 2", "C")
            If respuesta Then respuesta = Me.IF1.SendInvoiceItem("ARTICULO 1", "1000", "100", "2100", "M", "0", "0", "EXTRA", "EXTRA", "EXTRA", "1050", "0")
            If respuesta Then respuesta = Me.IF1.SendInvoiceItem("ARTICULO 2", "1000", "1200", "2100", "M", "0", "0", "", "", "", "1050", "0")
            If respuesta Then respuesta = Me.IF1.TransportClose
            If respuesta Then MsgBox "Coloque la siguiente hoja"
            If respuesta Then respuesta = Me.IF1.TransportOpen
            If respuesta Then respuesta = Me.IF1.SendInvoiceItem("ARTICULO 3", "1000", "1000", "2100", "M", "0", "0", "", "", "", "1050", "0")
            'If respuesta Then respuesta = Me.if1.GetInvoiceSubtotal("P", "LINDO SUB")
            If respuesta Then respuesta = Me.IF1.SendInvoicePayment("PAGO1", "3000", "T")
            If respuesta Then respuesta = Me.IF1.CloseInvoice("F", "A", "HOLA")

    End Select

Screen.MousePointer = 1

    'Las dos líneas que siguen creo que las agregué yo.
    MsgBox "respuesta = " & respuesta & Chr$(13) & "FiscalStatus = " & Me.IF1.FiscalStatus & Chr$(13) & "PrinterStatus = " & Me.IF1.PrinterStatus
    MsgBox "AnswerField_3: " & Me.IF1.AnswerField_3 & vbCrLf & "AnswerField_4: " & Me.IF1.AnswerField_4 & vbCrLf & "AnswerField_5: " & Me.IF1.AnswerField_5 & vbCrLf & "AnswerField_6: " & Me.IF1.AnswerField_6 & vbCrLf & "AnswerField_7: " & Me.IF1.AnswerField_7 & vbCrLf & "AnswerField_8: " & Me.IF1.AnswerField_8 & vbCrLf & "AnswerField_9: " & Me.IF1.AnswerField_9 & vbCrLf & "AnswerField_10: " & Me.IF1.AnswerField_10 & vbCrLf & "AnswerField_11: " & Me.IF1.AnswerField_11 & vbCrLf & "AnswerField_12: " & Me.IF1.AnswerField_12 & vbCrLf & "AnswerField_13: " & Me.IF1.AnswerField_13 & vbCrLf & "AnswerField_14: " & Me.IF1.AnswerField_14 & vbCrLf & "AnswerField_15: " & Me.IF1.AnswerField_15 & vbCrLf & "AnswerField_16: " & Me.IF1.AnswerField_16 & vbCrLf & "AnswerField_17: " & Me.IF1.AnswerField_17 & vbCrLf & "AnswerField_18: " & Me.IF1.AnswerField_18

End Sub

Private Sub Command2_Click(Index As Integer)
' **************************************************************************
' Propiedad intelectual EPSON ARGENTINA S.A.
' Programador: Gomez Guillermo
' Este software se entrega con fines didácticos y sin garantia alguna.
' EPSON NO ASUME responsabilidad legal alguna. El programador usa esta información
' bajo su propio riesgo y responsabilidad.
' **************************************************************************

Select Case Index

    Case 0
        respuesta = Me.IF1.CloseJournal("X", "P")
        
    Case 1
        respuesta = Me.IF1.CloseJournal("Z")
        
       
End Select
    MsgBox respuesta & Chr$(13) & Me.IF1.FiscalStatus & Chr$(13) & Me.IF1.PrinterStatus
    
End Sub


Private Sub Command3_Click()
    If Combo1.ListIndex > 0 Then
        IF1.PortNumber = Combo1.ListIndex
    End If
    If Combo2.ListIndex > 0 Then
        IF1.BaudRate = Combo2.Text
    End If
    
End Sub

Private Sub Form_Load()
' **************************************************************************
' Propiedad intelectual EPSON ARGENTINA S.A.
' Programador: Gomez Guillermo
' Este software se entrega con fines didácticos y sin garantia alguna.
' EPSON NO ASUME responsabilidad legal alguna. El programador usa esta información
' bajo su propio riesgo y responsabilidad.
' **************************************************************************
Dim i As Integer
Dim Nombre As String
Dim Ayuda As String

ReDim Funciones(1)
ReDim AyudaFunciones(1)

    Combo1.Clear
    Combo1.AddItem "Puerto"
    Combo1.AddItem "COM 1"
    Combo1.AddItem "COM 2"
    Combo1.AddItem "COM 3"
    Combo1.AddItem "COM 4"
    Combo1.AddItem "COM 5"
    Combo1.ListIndex = 0

    Combo2.Clear
    Combo2.AddItem "Velocidad"
    Combo2.AddItem "9600"
    Combo2.AddItem "19200"
    Combo2.AddItem "38400"
    Combo2.ListIndex = 0
    
End Sub

Function AddParam(NewParam As String, Optional Reset = False) As Integer
' **************************************************************************
' Propiedad intelectual EPSON ARGENTINA S.A.
' Programador: Gomez Guillermo
' Este software se entrega con fines didácticos y sin garantia alguna.
' EPSON NO ASUME responsabilidad legal alguna. El programador usa esta información
' bajo su propio riesgo y responsabilidad.
' **************************************************************************

'Agrega un parametro a la lista
Dim i As Integer
If Reset Then
    i = 0
    ReDim Parametros(i)
    Parametros(i) = NewParam
Else
    i = UBound(Parametros) + 1
    
    ReDim Preserve Parametros(i)
    Parametros(i) = NewParam
End If



End Function
