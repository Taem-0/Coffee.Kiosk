using System;
using System.Windows.Forms;

public class IdleMessageFilter : IMessageFilter
{
    private readonly Action _resetAction;

    public IdleMessageFilter(Action resetAction)
    {
        _resetAction = resetAction;
    }

    public bool PreFilterMessage(ref Message m)
    {
        // wtf is this ???
        const int WM_MOUSEMOVE = 0x0200;
        const int WM_LBUTTONDOWN = 0x0201;
        const int WM_RBUTTONDOWN = 0x0204;
        const int WM_KEYDOWN = 0x0100;
        const int WM_TOUCH = 0x0240;

        switch (m.Msg)
        {
            case WM_MOUSEMOVE:
            case WM_LBUTTONDOWN:
            case WM_RBUTTONDOWN:
            case WM_KEYDOWN:
            case WM_TOUCH:
                _resetAction();
                break;
        }

        return false;
    }
}
