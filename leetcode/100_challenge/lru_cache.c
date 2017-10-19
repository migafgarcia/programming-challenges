#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include <math.h>


typedef struct ht_item {
    int key;
    int value;
    struct ht_item* prev;
    struct ht_item* next;
} ht_item;

typedef struct {
    int size;
    int count;
    int prime_1;
    int prime_2;
    ht_item** items;
} ht_hash_table;

typedef struct {
	ht_hash_table* h;
	ht_item* first;
	ht_item* last;
	int capacity;
} LRUCache;

static ht_item HT_DELETED_ITEM = {0, 0};

/*
 * Return whether x is prime or not
 *
 * Returns:
 *   1  - prime
 *   0  - not prime
 *   -1 - undefined (i.e. x < 2)
 */
int is_prime(const int x) {
    if (x < 2) { return -1; }
    if (x < 4) { return 1; }
    if ((x % 2) == 0) { return 0; }
    for (int i = 3; i <= floor(sqrt((double) x)); i += 2) {
        if ((x % i) == 0) {
            return 0;
        }
    }
    return 1;
}

int next_prime(int x) {
    while (is_prime(x) != 1) {
        x++;
    }
    return x;
}

static ht_item* ht_new_item(int k, int v, ht_item* prev, ht_item* next) {
    ht_item* i = malloc(sizeof(ht_item));
    i->key = k;
    i->value = v;
    i->prev = prev;
    i->next = next;
    return i;
}

ht_hash_table* ht_new(int capacity) {
    
    ht_hash_table* ht = malloc(sizeof(ht_hash_table));
    ht->size = capacity;
    ht->count = 0;
    ht->items = calloc((size_t)ht->size, sizeof(ht_item*));
    ht->prime_1 = next_prime(capacity);
	ht->prime_2 = next_prime(ht->prime_1 + 1);
    return ht;
}

static int ht_hash(const int k, const int prime, const int m) {
    return (k * prime) % m;
}

static int ht_get_hash(const int k, const int num_buckets, const int attempt, const int prime_1, const int prime_2) {
    const int hash_a = ht_hash(k, prime_1, num_buckets);
    const int hash_b = ht_hash(k, prime_2, num_buckets);
    return (hash_a + (attempt * (hash_b + 1))) % num_buckets;
}

void ht_insert(ht_hash_table* ht, ht_item* item) {
    int index = ht_get_hash(item->key, ht->size, 0, ht->prime_1, ht->prime_2);
    ht_item* cur_item = ht->items[index];
    int i = 1;
    while (cur_item != NULL && cur_item != &HT_DELETED_ITEM) {
        index = ht_get_hash(item->key, ht->size, i, ht->prime_1, ht->prime_2);
        cur_item = ht->items[index];
        i++;
    } 
    ht->items[index] = item;
    ht->count++;
}

ht_item* ht_search(ht_hash_table* ht, const int key) {
    int index = ht_get_hash(key, ht->size, 0, ht->prime_1, ht->prime_2);
    ht_item* item = ht->items[index];
    int i = 1;
    while (item != NULL) {
    	if (item != &HT_DELETED_ITEM) { 
	        if (item->key == key) {
	            return item;
	        }
    	}
        index = ht_get_hash(key, ht->size, i, ht->prime_1, ht->prime_2);
        item = ht->items[index];
        i++;
    } 
    return NULL;
}

void ht_delete(ht_hash_table* ht, const int key) {
    int index = ht_get_hash(key, ht->size, 0, ht->prime_1, ht->prime_2);
    ht_item* item = ht->items[index];
    int i = 1;
    while (item != NULL) {
        if (item != &HT_DELETED_ITEM) {
            if (item->key == key) {
                free(item);
                ht->items[index] = &HT_DELETED_ITEM;
                break;
            }
        }
        index = ht_get_hash(key, ht->size, i, ht->prime_1, ht->prime_2);
        item = ht->items[index];
        i++;
    } 
    ht->count--;
}


LRUCache* lRUCacheCreate(int capacity) {
	LRUCache* cache = malloc(sizeof(LRUCache));
	cache->h = ht_new(100000);
	cache->capacity = capacity;
	cache->first = NULL;
	cache->last = NULL;
	return cache;
}

int lRUCacheGet(LRUCache* obj, int key) {

	ht_item* item = ht_search(obj->h, key);

	if(!item)
		return -1;

	if(item == obj->first) {
		return item->value;
	}
	else if(item == obj->last) {
		// remove from last
    	obj->last = obj->last->prev;
    	obj->last->next = NULL;

    	// replace first
    	item->prev = NULL;
    	item->next = obj->first;
    	obj->first->prev = item;
    	obj->first = item;
	}
	else {
		item->prev->next = item->next;
		item->next->prev = item->prev;

    	// replace first
    	item->prev = NULL;
    	item->next = obj->first;
    	obj->first->prev = item;
    	obj->first = item;
	}

	return item->value;
}

void lRUCachePut(LRUCache* obj, int key, int value) {



	ht_item* item = ht_search(obj->h, key);

	if(item) {
		item->value = value;
		lRUCacheGet(obj, key);
		return;
	}

    if(!obj->first && !obj->last) {
    	item = ht_new_item(key, value, NULL, NULL);
    	obj->first = item;
    	obj->last = item;
    }
    else if(obj->first == obj->last) {	
    	item = ht_new_item(key, value, NULL, obj->last);
    	obj->first = item;
    	obj->last->prev = obj->first;
    }
    else {
    	item = ht_new_item(key, value, NULL, obj->first);
    	obj->first->prev = item;
    	obj->first = item;
    }

    ht_hash_table* h = obj->h;


    if(h->count == obj->capacity) {

    	ht_item* last = obj->last;
    	obj->last = obj->last->prev;
    	obj->last->next = NULL;
    	ht_delete(h, last->key);
    }

    ht_insert(obj->h, item);


}

void print_list(LRUCache* obj) {
	ht_item* curr = obj->first;

	while(curr) {
		printf("(%d, %d) ", curr->key, curr->value);
		curr = curr->next;
	}

	printf("\n");
}
