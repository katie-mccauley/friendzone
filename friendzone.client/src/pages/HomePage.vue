<template>
  <div class="container-fluid">
    <div class="row">
      <div
        class="col-3 m-3 bg-white rounded shadow"
        v-for="p in profiles"
        :key="p.id"
        @click="setActive(p.id)"
        data-bs-toggle="modal"
        data-bs-target="#profile"
      >
        <img :src="p.picture" class="img-fluid" alt="" />
        {{ p.name }}
      </div>
    </div>
  </div>
  <Modal id="profile">
    <template #title>This is the active profile</template>
    <template #body>
      <div class="container-fluid">
        <div class="row">
          <div class="col-10 bg-white text-dark">
            <h3>
              <i class="mdi mdi-heart selectable" @click="createFollow()"></i>
            </h3>
            <img :src="active.picture" class="img-fluid" alt="" />
            {{ active.name }}

            <h1>Followers</h1>
            <h2 v-for="f in followers" :key="f.id">
              {{ f.name }}
            </h2>
            <h1>Following</h1>
            <h2 v-for="fo in following" :key="fo.id">{{ fo.name }}</h2>
          </div>
        </div>
      </div>
    </template>
  </Modal>
</template>

<script>
import { computed, onMounted } from "@vue/runtime-core"
import { logger } from "../utils/Logger"
import { profilesService } from "../services/ProfilesService"
import { AppState } from "../AppState"
import { followService } from "../services/FollowService"
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
      profiles: computed(() => AppState.profiles),
      async setActive(id) {
        try {
          await profilesService.getOne(id)
          await followService.getFollowers(AppState.activeProfile.id)
          await followService.getFollowing(AppState.activeProfile.id)
        } catch (error) {
          logger.error(error)
        }
      },
      async createFollow() {
        try {
          let follow = {
            followerId: AppState.account.id,
            followingId: AppState.activeProfile.id
          }
          await followService.createFollow(follow)
        } catch (error) {
          logger.error(error)

        }
      },
      active: computed(() => AppState.activeProfile),
      followers: computed(() => AppState.followers),
      following: computed(() => AppState.following)
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
