<template>
  <nav class="bg-white shadow sticky top-0 z-50">
    <div class="max-w-6xl mx-auto flex justify-between items-center px-4 py-3">
      <h1 class="text-2xl font-bold text-amber-600">🍛 Restaurant Menu</h1>
      <div class="space-x-6">
        <router-link to="/" class="text-gray-700 hover:text-amber-600 font-medium">View Menu</router-link> |
      
        <router-link to="/add" class="text-gray-700 hover:text-amber-600 font-medium">Add Item</router-link> |
      </div>  
    </div>
  </nav>

  <router-view />
</template>

<style scoped>
nav {
  padding: 1rem;
  background: #eee;
  text-align: center;
}
nav a {
  margin: 0 1rem;
  text-decoration: none;
  color: #333;
}
nav a.router-link-active {
  font-weight: bold;
  color: #2d8cf0;
}
</style>
