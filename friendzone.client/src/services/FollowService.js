import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class FollowService {

  async getFollowers(id) {
    const res = await api.get('api/profiles/' + id + '/followers')
    logger.log("All of the followers for the active person")
    AppState.followers = res.data
  }

  async getFollowing(id) {
    const res = await api.get('api/profiles/' + id + '/following')
    logger.log("All of the following for the active person")
    AppState.following = res.data
  }

  async createFollow(follow) {
    const res = await api.post('api/follow', follow)
    logger.log("creating a new friend", res.data)
    AppState.following.push(res.data)
  }
}

export const followService = new FollowService()