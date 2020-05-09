#include <stdio.h> 
#include <malloc.h>
#include <string.h>
#include <stdlib.h>

/* Структура, описывающая элемент двунаправленного списка */
typedef struct Item {
    int digit;
    struct Item* next;
    struct Item* prev;
} Item;

/* Структура, описывающая многоразрядное число */
typedef struct MNumber {
    Item* head;
    Item* tail;
    int count;
} MNumber;

MNumber CopyMNumber(MNumber n1, int diff);
MNumber Division(MNumber n1, MNumber n2);
MNumber MultiplyBy10(MNumber n1, int num);
MNumber SumMNumber(MNumber n1, MNumber n2);
MNumber CreateMNumber(const char initStr[]);
void AddDigit(MNumber* number, int digit);
void PrintMNumber(MNumber number);
MNumber DiffMNumber(MNumber n1, MNumber n2);
MNumber NOK(MNumber a, MNumber b);
MNumber NOD(MNumber a, MNumber b);
int EqualityTest(MNumber a, MNumber b);
MNumber Multiplication(MNumber a, MNumber b);

int main(void)
{
    MNumber a = CreateMNumber("148967280000");
    MNumber b = CreateMNumber("22556789708");
    MNumber c = NOK(a, b);
    printf("Number 1: ");
    PrintMNumber(a);
    printf("Number 2: ");
    PrintMNumber(b);
    printf("NOD: ");
    PrintMNumber(NOD(a, b));
    printf("NOK: ");
    PrintMNumber(c);
    return 0;
}

MNumber CreateMNumber(const char initStr[])
{
    MNumber number = { NULL, NULL };
    int n;
    for (n = strlen(initStr) - 1; n >= 0; n--)
        AddDigit(&number, initStr[n] - '0');
    return number;
}

void AddDigit(MNumber* number, int digit)
{
    Item* p = (Item*)malloc(sizeof(Item));
    p->digit = digit;
    p->next = p->prev = NULL;
    if (number->head == NULL) {
        number->head = number->tail = p;
        number->count = 1;
    }
    else {
        number->tail->next = p;
        p->prev = number->tail;
        number->tail = p;
        (number->count)++;
    }
}

MNumber SumMNumber(MNumber n1, MNumber n2)
{
    MNumber sum = CreateMNumber("");
    Item* p1 = n1.head, * p2 = n2.head;
    int digit, pos = 0, s1, s2;
    while (p1 || p2) {
        if (p1) { s1 = p1->digit; p1 = p1->next; }
        else s1 = 0;
        if (p2) { s2 = p2->digit; p2 = p2->next; }
        else s2 = 0;
        digit = (s1 + s2 + pos) % 10;
        pos = (s1 + s2 + pos) / 10;
        AddDigit(&sum, digit);
    }
    if (pos != 0) {
        AddDigit(&sum, pos);
    }
    return sum;
}

MNumber DiffMNumber(MNumber n1, MNumber n2)
{
    MNumber diff = { NULL, NULL };
    Item* a = n1.head, * b = n2.head;
    int digit = 0, s1 = 0, s2 = 0, pnt = 0;
    while (a != NULL) {
        s1 = a->digit;
        a = a->next;
        if (b != NULL) {
            s2 = b->digit;
            b = b->next;
        }
        else {
            s2 = 0;
        }
        if (pnt != 0) {
            s1--;
            pnt = 0;
        }
        if (s1 < s2) {
            s1 += 10;
            pnt = 1;
        }
        digit = s1 - s2;
        AddDigit(&diff, digit);
    }
    a = diff.tail;
    while (a->digit == 0) {
        if (a->prev == NULL) {
            diff.head = diff.tail = NULL;
            break;
        }
        a->prev->next = NULL;
        a = a->prev;
        diff.tail = a;
        diff.count--;
    }
    return diff;
}

void PrintMNumber(MNumber number)
{
    Item* p = number.tail;
    while (p) {
        printf("%d", p->digit);
        p = p->prev;
    }
    printf("\n");
}

MNumber CopyMNumber(MNumber n1, int diff)
{
    MNumber num = { NULL, NULL };
    Item* p = n1.head;
    while (diff != 0) {
        p = p->next;
        diff--;
    }
    while (p != NULL) {
        AddDigit(&num, p->digit);
        p = p->next;
    }
    return num;
}

MNumber NOD(MNumber n1, MNumber n2) {
    MNumber num1 = { NULL, NULL };
    MNumber num2 = { NULL, NULL };
    MNumber num = { NULL, NULL };
    MNumber addNum = { NULL, NULL };
    num1 = CopyMNumber(n1, 0);
    num2 = CopyMNumber(n2, 0);
    int diff = 0;
    while (EqualityTest(num1, num2) != 0) {
        addNum.head = addNum.tail = NULL;
        if (EqualityTest(num1, num2) == 1) {
            diff = num1.count - num2.count;
            if (num1.tail->digit <= num2.tail->digit && diff > 0) {
                diff--;
            }
            num = MultiplyBy10(num2, diff);
            num1 = DiffMNumber(num1, num);
        }
        else {
            diff = num2.count - num1.count;
            if (num1.tail->digit >= num2.tail->digit && diff > 0) {
                diff--;
            }
            num = MultiplyBy10(num1, diff);
            num2 = DiffMNumber(num2, num);
        }
    }
    return num1;
}

int EqualityTest(MNumber n1, MNumber n2) {
    Item* a = n1.tail, * b = n2.tail;
    if (n1.count < n2.count) {
        return -1;
    }
    else if (n1.count > n2.count) {
        return 1;
    }
    while (a != NULL && b != NULL) {
        if (a->digit > b->digit) {
            return 1;
        }
        else if (a->digit < b->digit) {
            return -1;
        }
        a = a->prev;
        b = b->prev;
    }
    return 0;
}

MNumber NOK(MNumber n1, MNumber n2) {
    MNumber num1 = { NULL, NULL };
    MNumber nok = { NULL, NULL };
    MNumber mul = Multiplication(n1, n2);
    MNumber nod = NOD(n1, n2);
    num1 = Division(mul, nod);
    Item* a = num1.tail;
    while (a != NULL) {
        AddDigit(&nok, a->digit);
        a = a->prev;
    }
    return nok;
}

MNumber Multiplication(MNumber n1, MNumber n2) {
    Item* a = n1.head, * b = n2.head;
    MNumber multip = { NULL, NULL };
    MNumber* terms = (MNumber*)malloc(n2.count * sizeof(MNumber));
    if (!terms) {
        printf("Allocation failure.");
        exit(0);
    }
    int i = 0, s1 = 0, s2 = 0, pos = 0, digit = 0, j = 0;
    for (i = 0; i < n2.count; i++) {
        a = n1.head;
        terms[i].head = terms[i].tail = NULL;
        while (a != NULL) {
            s1 = a->digit;
            s2 = b->digit;
            digit = s1 * s2;
            if (pos != 0) {
                digit += pos;
                pos = 0;
            }
            if (digit > 9) {
                pos = digit / 10;
                digit %= 10;
            }
            AddDigit(&terms[i], digit);
            a = a->next;
        }
        if (pos != 0) {
            AddDigit(&terms[i], pos);
            pos = 0;
        }
        for (j = 0; j < i; j++) {
            terms[i] = MultiplyBy10(terms[i], 1);
        }
        multip = SumMNumber(terms[i], multip);
        b = b->next;
    }
    free(terms);
    return multip;
}

MNumber MultiplyBy10(MNumber n1, int num) {
    MNumber number = { NULL, NULL };
    Item* p = n1.head;
    while (num != 0) {
        AddDigit(&number, 0);
        num--;
    }
    while (p != NULL) {
        AddDigit(&number, p->digit);
        p = p->next;
    }
    return number;
}

MNumber Division(MNumber n1, MNumber n2) {
    Item* a = n1.tail;
    MNumber addNum = { NULL, NULL };
    MNumber quotient = { NULL, NULL };
    MNumber divider = { NULL, NULL };
    MNumber div = { NULL, NULL };
    int i = 0, num = n1.count - n2.count, quot = 1;
    divider = CopyMNumber(n2, 0);
    addNum = CopyMNumber(n1, num);
    if (EqualityTest(addNum, divider) == -1) {
        num--;
        addNum = CopyMNumber(n1, num);
    }
    for (i = 0; i < n1.count - num - 1; i++) {
        a = a->prev;
    }
    while (1) {
        a = a->prev;
        quot = 1;
        div.head = div.tail = NULL;
        divider = n2;
        while (EqualityTest(addNum, divider) != 0) {
            if (EqualityTest(addNum, divider) == -1) {
                divider = DiffMNumber(divider, n2);
                quot--;
                break;
            }
            quot++;
            divider = SumMNumber(divider, n2);
        }
        AddDigit(&quotient, quot);
        if (a == NULL) {
            break;
        }
        addNum = DiffMNumber(addNum, divider);
        AddDigit(&div, a->digit);
        addNum = MultiplyBy10(addNum, 1);
        addNum = SumMNumber(addNum, div);
    }
    return quotient;
}
