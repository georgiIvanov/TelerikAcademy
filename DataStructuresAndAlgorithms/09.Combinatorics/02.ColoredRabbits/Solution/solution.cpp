#include <iostream>
#include <cmath>
using namespace std;
#define MAXCOUNT 1000001
int cache[MAXCOUNT + 1];
int main()
{
    int n;
    cin >> n;
    int replies[n];
    for(int i = 0; i < n; i++)
    {
        cin >> replies[i];
    }
    for(int i = 0; i < n; i++)
    {
        cache[replies[i]+1]++;
    }
    int rabbits = 0;
    for (int i = 0; i <= MAXCOUNT; i++)
    {
        if (cache[i] > 0)
        {
            rabbits += (int)ceil((double)cache[i] / i) * i;
        }
    }
    cout << rabbits << endl;
    return 0;
}

