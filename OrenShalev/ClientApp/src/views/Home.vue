<template>

        <v-flex>
            <v-container grid-list-md text-xs-center>
                <v-layout row wrap>
                    <v-flex xs6>

                        <v-card>
                            <v-toolbar color="light-blue" dark>
                                <v-toolbar-title>ChapterS</v-toolbar-title
                                <v-spacer></v-spacer>
                            </v-toolbar>
                            <!-- start of the Chapter list -->
                            <v-list two-line subheader>

                                <v-list-tile v-for="item in appData"
                                             :key="item.id"
                                             active
                                             @click="toShow(item)">
                                    <v-list-tile-avatar>
                                        <v-icon></v-icon>
                                    </v-list-tile-avatar>

                                    <v-list-tile-content>
                                        <v-list-tile-title class="text--primary">{{ item.name }}</v-list-tile-title>
                                        <v-list-tile-sub-title>{{ item.code }}</v-list-tile-sub-title>
                                    </v-list-tile-content>
                                </v-list-tile>
                                <v-divider inset></v-divider>

                            </v-list>
                            <!-- end of Chapter list -->
                        </v-card>
                       
                    </v-flex>

                    <v-flex xs6>
                        <v-card>
                            <v-toolbar color="light-blue" dark>


                                <v-toolbar-title>roots</v-toolbar-title>

                                <v-spacer></v-spacer>

                            </v-toolbar>
                            <!-- start of Roots list -->
                            <v-list two-line subheader>

                                <v-list-tile v-for="item in isSelected.roots"
                                             :key="item.id"
                                             @click="onShowD(item)">
                                    <v-list-tile-avatar>
                                        <v-icon></v-icon>
                                    </v-list-tile-avatar>

                                    <v-list-tile-content>
                                        <v-list-tile-title>{{ item.name }}</v-list-tile-title>
                                        <v-list-tile-sub-title>{{ item.code }}</v-list-tile-sub-title>
                                    </v-list-tile-content>

                                    <v-list-tile-action>
                                        <!-- start of the edit dialog -->
                                        <v-dialog v-model="dialog" persistent max-width="600px">

                      <v-card>
                          <v-card-title>
                              <span class="headline">Data Profile</span>
                          </v-card-title>
                          <v-card-text>
                              <v-container grid-list-md  >
                                  <v-layout wrap>
                                      <v-flex xs12 sm6 md4>
                                          <v-text-field label="code*" v-model="isSelected2.code" disabled></v-text-field>
                                      </v-flex>
                                      <v-flex xs12 sm6 md4>
                                          <v-text-field label="name" v-model="isSelected2.name"  hint="the root name"></v-text-field>
                                      </v-flex>
                                      </v-layout>
                              </v-container>
                              <small>*indicates required field</small>
                          </v-card-text>
                          <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn color="blue darken-1" flat
                                     :loading="isUpdate"
                                     :disabled="isUpdate"
                                     @click="onRootUpdate(item)">Update</v-btn>
                              <v-btn color="blue darken-1" flat @click="dialog = false">Close</v-btn>
                          </v-card-actions>
                      </v-card>
                  </v-dialog>
                                        <!-- end of dialog -->
                                    </v-list-tile-action>

                                </v-list-tile>

                                <v-divider inset></v-divider>

                            </v-list>
                            <!-- end of Roots list -->
                        </v-card>
                    </v-flex>
                </v-layout>
                </v-container>
</v-flex>
</template>

<script>
    //axios is for async get and post
    import axios from 'axios'
  export default {
        data: () => ({
          appData: [],// axios puts here
      chaptersContext: [], // hold all the chapters
      rootsContext: [], //hold all the roots
          dialog: false,//for the edit dialog
          isUpdate:false,//for async update 
          isSelected: {},//for Chapters table
          isSelected2: {}//for Roots table
    }),

    // watch the appData and create rootcontext is changes
    watch: {
        appData(val) {
            console.log("update watch appData ")
            //group all roots to rootsContext
            this.rootsContext = val.reduce((acc, cur) => { 
                return [...acc, ...cur.roots]
            }, []).sort()
            //end of group
      }
    },

        methods: {
            //show the chapter that user selected
            toShow(val) {
                console.log('in toShow == ' + val)
                this.isSelected = val
            },//end show the chapter that user selected

            //for dialog show the root that user selected
            onShowD(val) {
                console.log('in onShowD == ' + val.name)
                this.isSelected2 = val
                this.dialog = true
            },//end dialog show the root that user selected

            //Get all data from back-end(sampledata)
            async onGetAll() {
                console.log('in onGetAll')
                this.isUpdate = true
                console.log('in onGetAll ==> axios')
                await axios.get('/api/SampleData/GetChaptersAsync')
                    .then(response => {
                        console.log('response==>' + response + '==' + JSON.stringify(response.data))
                        this.appData = response.data
                    })
                    .catch(err => console.log(err))
                this.isUpdate = false
            },
            ///end Get all
            
            //update root
            async onRootUpdate(val) {
                this.isUpdate = true
                console.log('in update == ' + val.name)
                console.log('in update == ' + this.isSelected2.name)
                var upData = this.isSelected2
                await axios.post('/api/SampleData/UpdateCarAsync', upData).then(response => {
                    if (this.isSelected2 === response.data) {
                        console.log('good update')
                    } else {
                        console.log(' not good update  ' + response.data)
                    }
                    //val = response.data
                })
                    .catch(err => {
                        console.log(err)
                    })
                this.isUpdate = false
        }//end update root
        },
        //load data on page start
        beforeMount() {
            this.onGetAll()
        }
    }
  
</script>
