#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>

/* Структура, описывающая элемент двунаправленного списка */
typedef struct ItemList {
	int digit;
	struct ItemList* next;
	struct ItemList* prev;
} ItemList;

/* Структура, описывающая многоразрядное число */
typedef struct MNumber {
	ItemList* head;
	ItemList* tail;
	int count;
} MNumber;

/* Структура, описывающая узел дерева */
typedef struct ItemTree {
	int data;
	struct ItemTree* left;
	struct ItemTree* right;
} ItemTree;

void AddNode(int data, ItemTree** node);
void LeftOrder(ItemTree* node);
MNumber CreateMNumber(const char initStr[]);
void AddDigit(MNumber* number, int digit);
void CreateTree(MNumber a);
void Delete(ItemTree** node, ItemTree** prevNode);
void pr(ItemTree** node, ItemTree** prevNode);

ItemTree* root = NULL;
int flag = 0;

void main(void)
{
	MNumber numList = CreateMNumber("1 0 -6 -3 -5 2 6 4 3 5 9");
	CreateTree(numList);
	LeftOrder(root);
	printf("\n");
	pr(&root, &root);
	if (flag == 1) {
		puts("\nRoot cannot be deleted.\n");
	}
	LeftOrder(root);
}

void pr(ItemTree** node, ItemTree** prevNode) {
	if ((*node) != NULL && (*node)->left != NULL) {
		pr(&(*node)->left, &(*node));
	}
	if ((*node) != NULL && (*node)->data < 0) {
		if (*node != root) {
			Delete(&(*node), &(*prevNode));
			pr(&root, &root);
		}
		else {
			flag = 1;
		}
	}
	if ((*node) != NULL && (*node)->right != NULL) {
		pr(&(*node)->right, &(*node));
	}
}

void Delete(ItemTree** node, ItemTree** prevNode)
{
	if ((*node)->left == NULL && (*node)->right == NULL) {
		if ((*prevNode)->left == (*node))
			(*prevNode)->left = NULL;
		else if ((*prevNode)->right == (*node))
			(*prevNode)->right = NULL;
	}
	else if ((*node)->left == NULL) {
		if ((*prevNode)->left == (*node))
			(*prevNode)->left = (*node)->right;
		else if ((*prevNode)->right == node)
			(*prevNode)->right = (*node)->right;
	}
	else if ((*node)->right == NULL) {
		if ((*prevNode)->left == node)
			(*prevNode)->left = (*node)->left;
		else if ((*prevNode)->right == node)
			(*prevNode)->right = (*node)->left;
	}
	else {
		ItemTree* newNode = (ItemTree*)calloc(1, sizeof(ItemTree));
		ItemTree* newNodePrev = (ItemTree*)calloc(1, sizeof(ItemTree));
		newNode = (*node)->left;
		newNodePrev = (*node)->left;
		while (newNode->right != NULL) {
			newNodePrev = newNode;
			newNode = newNode->right;
		}
		newNode->right = (*node)->right;
		newNode->left = (*node)->left;
		newNodePrev->right = NULL;
		if ((*prevNode)->left == (*node))
			(*prevNode)->left = newNode;
		else if ((*prevNode)->right == (*node)) 
			(*prevNode)->right = newNode;
	}
}

void CreateTree(MNumber a)
{
	ItemList* p1 = a.head;
	while (p1 != NULL) {
		AddNode(p1->digit, &root);
		p1 = p1->next;
	}
}

void AddNode(int data, ItemTree **node)
{
	if (*node == NULL) {
		*node = (ItemTree*)calloc(1, sizeof(ItemTree));
		(*node)->data = data;
		(*node)->left = (*node)->right = NULL;
	}
	else {
		if (data < (*node)->data) {
			AddNode(data, &(*node)->left);
		}
		else if (data > (*node)->data) {
			AddNode(data, &(*node)->right);
		}
		else {
			puts("There is such element in the tree");
		}
	}
}

void LeftOrder(ItemTree* node)
{
	if (node->left != NULL) {
		LeftOrder(node->left);
	}
	printf("%d ", node->data);
	if (node->right != NULL) {
		LeftOrder(node->right);
	}
}

MNumber CreateMNumber(const char initStr[])
{
	MNumber number = { NULL, NULL };
	int n;
	for (n = 0; n < strlen(initStr); n++) {
		if (initStr[n] == ' ') {
			continue;
		}
		else if (initStr[n] == '-') {
			AddDigit(&number, -(initStr[n + 1] - '0'));
			n++;
		}
		else {
			AddDigit(&number, initStr[n] - '0');
		}
	}
	return number;
}

void AddDigit(MNumber* number, int digit)
{
	ItemList* p = (ItemList*)malloc(sizeof(ItemList));
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