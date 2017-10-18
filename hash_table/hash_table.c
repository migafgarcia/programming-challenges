#include <stdlib.h>
#include <string.h>
#include <stdio.h>

#include "hash_table.h"

static int SIZE = 10000;
static int DELETED = 10001;
static int HT_PRIME_1 = 10007;
static int HT_PRIME_2 = 10301;

static ht_item HT_DELETED_ITEM = {0, 0};

static ht_item* ht_new_item(const int k, const int v) {
    ht_item* i = malloc(sizeof(ht_item));
    i->key = k;
    i->value = v;
    return i;
}

ht_hash_table* ht_new() {
    ht_hash_table* ht = malloc(sizeof(ht_hash_table));

    ht->size = SIZE;
    ht->count = 0;
    ht->items = calloc((size_t)ht->size, sizeof(ht_item*));
    return ht;
}

static void ht_del_item(ht_item* i) {
    //free(i->key);
    //free(i->value);
    free(i);
}


void ht_del_hash_table(ht_hash_table* ht) {
    for (int i = 0; i < ht->size; i++) {
        ht_item* item = ht->items[i];
        if (item != NULL) {
            ht_del_item(item);
        }
    }
    free(ht->items);
    free(ht);
}

static int ht_hash(const int k, const int prime, const int m) {
    return (k * prime) % m;
}

static int ht_get_hash(const int k, const int num_buckets, const int attempt) {
    const int hash_a = ht_hash(k, HT_PRIME_1, num_buckets);
    const int hash_b = ht_hash(k, HT_PRIME_2, num_buckets);
    return (hash_a + (attempt * (hash_b + 1))) % num_buckets;
}


void ht_insert(ht_hash_table* ht, const int key, const int value) {
    ht_item* item = ht_new_item(key, value);
    int index = ht_get_hash(item->key, ht->size, 0);
    ht_item* cur_item = ht->items[index];
    int i = 1;
    while (cur_item != NULL && cur_item != &HT_DELETED_ITEM) {
        index = ht_get_hash(item->key, ht->size, i);
        cur_item = ht->items[index];
        i++;
    } 
    ht->items[index] = item;
    ht->count++;
}

int ht_search(ht_hash_table* ht, const int key) {
    int index = ht_get_hash(key, ht->size, 0);
    ht_item* item = ht->items[index];
    int i = 1;
    while (item != NULL) {
    	if (item != &HT_DELETED_ITEM) { 
	        if (item->key == key) {
	            return item->value;
	        }
    	}
        index = ht_get_hash(key, ht->size, i);
        item = ht->items[index];
        i++;
    } 
    return DELETED;
}



void ht_delete(ht_hash_table* ht, const int key) {
    int index = ht_get_hash(key, ht->size, 0);
    ht_item* item = ht->items[index];
    int i = 1;
    while (item != NULL) {
        if (item != &HT_DELETED_ITEM) {
            if (item->key == key) {
                ht_del_item(item);
                ht->items[index] = &HT_DELETED_ITEM;
            }
        }
        index = ht_get_hash(key, ht->size, i);
        item = ht->items[index];
        i++;
    } 
    ht->count--;
}

void ht_print(ht_hash_table* h) {
    for(int i = 0; i < h->size; i++) {
        if(h->items) {
            printf("%d\n", h->items[0]->key);
        }
    }
}