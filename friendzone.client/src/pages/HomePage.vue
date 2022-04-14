<template>
  <div class="container-fluid">
    <div class="row">
      <div
        class="col-3 m-3 bg-white rounded shadow"
        v-for="p in profiles"
        :key="p.id"
      >
        <img :src="p.picture" class="img-fluid" alt="" />
        {{ p.name }}
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from "@vue/runtime-core"
import { logger } from "../utils/Logger"
import { profilesService } from "../services/ProfilesService"
import { AppState } from "../AppState"
export default {
  name: 'Home',
  setup() {
    onMounted(async () => {
      try {
        await profilesService.getAll()
      } catch (error) {
        logger.error(error)
      }
    })
    return {
      profiles: computed(() => AppState.profiles)
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
  .home-card {
    width: 50vw;
    > img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
