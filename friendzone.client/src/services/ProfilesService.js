import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class ProfilesService {

  async getAll() {
    const res = await api.get('api/profiles')
    logger.log("all profiles", res.data)
    AppState.profiles = res.data
  }
}

export const profilesService = new ProfilesService()