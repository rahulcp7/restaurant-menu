<template>
  <div>
    <nav>
      <router-link to="/">View Menu</router-link> |
      <router-link to="/add">Add Item</router-link>
    </nav>

    <router-view />
  </div>
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
