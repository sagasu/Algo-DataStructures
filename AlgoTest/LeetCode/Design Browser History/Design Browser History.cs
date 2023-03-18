public class BrowserHistory {
    private readonly string[] _history = new string[101];
    private int _curr = -1;
    private int _top = -1;

    public BrowserHistory(string homepage) => Visit(homepage);

    public void Visit(string url) {
        _history[++_curr] = url;
        _top = _curr;
    }

    public string Back(int steps) {
        if (steps > _curr) steps = _curr;
        _curr -= steps;
        return _history[_curr];
    }

    public string Forward(int steps) {
        if (_curr + steps > _top) steps = _top - _curr;
        _curr += steps;
        return _history[_curr];
    }
}