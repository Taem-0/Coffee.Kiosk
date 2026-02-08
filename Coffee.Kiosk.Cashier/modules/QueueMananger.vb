Module QueueManager

    Public Function GenerateQueueNumber() As String
        Try
            Dim today As Date = DateTime.Now.Date
            Dim queueData = OrderManager.LoadQueueData()

            If queueData.LastQueueDate < today Then
                queueData.LastQueueDate = today
                queueData.LastQueueNumber = 1
            Else
                queueData.LastQueueNumber += 1
            End If

            OrderManager.SaveQueueData(queueData)

            Return $"Q-{queueData.LastQueueNumber:D3}"

        Catch ex As Exception
            Return $"Q-{DateTime.Now:HHmmss}"
        End Try
    End Function

    Public Function GetCurrentQueueNumber() As String
        Try
            Dim queueData = OrderManager.LoadQueueData()
            Dim today As Date = DateTime.Now.Date

            If queueData.LastQueueDate < today Then
                Return "Q-001"
            Else
                Return $"Q-{(queueData.LastQueueNumber + 1):D3}"
            End If

        Catch ex As Exception
            Return "Q-001"
        End Try
    End Function

End Module