#include<stdio.h>

int main() {
    char hello[100];
    int a, b;
    float c;
    scanf("%[^\n]", hello);
    scanf("%d%d%f", &a, &b, &c);
    printf("str=%s\na=%d\nb=%d\nc=%.2f", hello, a, b, c);
    return a+b+c;
}
